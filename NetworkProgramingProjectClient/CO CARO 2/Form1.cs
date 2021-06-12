using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CO_CARO_2
{
    
    public partial class fmCoCaro : Form
    {
        public static int ChieuRongBanCo;
        public static int ChieuCaoBanCo;
        private Graphics grp;
        private C_DieuKhien DieuKhien;
        private fmLuatChoi LuatChoi;
        public SocketManager socket;
        public SelectUserName selectUserName;
        public SelectOpponent selectOpponent;


        public fmCoCaro()
        {
            InitializeComponent();
            //vẽ nên pnlBanCo
            grp = pnlBanCo.CreateGraphics();


            //lấy chiều rộng và chiều cao pnBanCo để vẽ bàn cờ
            ChieuCaoBanCo = pnlBanCo.Height;
            ChieuRongBanCo = pnlBanCo.Width;



            socket = new SocketManager();
            

            //khởi tạo đối tượng điều khiển trò chơi
            DieuKhien = new C_DieuKhien(socket);
            selectUserName = new SelectUserName(this, socket);

            selectOpponent = new SelectOpponent(this, socket);

            LuatChoi = new fmLuatChoi();
            pictureChuoi1.Visible = false;
            logo.Visible = false;
            //avp_btn.Checked = true;

            DieuKhien.LuotDi = 1;
            //chơiVớiMáyToolStripMenuItem_Click();
            DieuKhien.PanelGayBan = panelGayban;
            DieuKhien.TextGayBan = textGayBan;
            DieuKhien.PictureChuoi1 = pictureChuoi1;
            ConnectServer();
        }

        public void ConnectServer()
        {
            if (!socket.isConnected)
            {
                if (!socket.ConnectServer())
                {
                    Console.WriteLine("Can not connect to Serrverr");

                    /*socket.isConnected = true;
                    *//*pnlChessBoard.Enabled = true;*//*
                    socket.CreateServer();*/

                }
                else
                {
                    Console.WriteLine("Connected to Serrver");
                    selectUserName.ServerMessage = "Đã có kết nối đến server";
                    
                    /*pnlChessBoard.Enabled = false;*/
                    /*socket.Send(new SocketData(400, "test", new Point(2, 3)));*/
                    Listen();
                }
            }
        }
        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                SocketData data = null;
                try
                {
                    data = (SocketData)socket.Receive();

                    Console.WriteLine("Data da desrialize = {0}", data.Command);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Listen Error : {0}", e.Message);

                }
                ProcessData(data);
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            if (data != null)
            {
                switch (data.Command)
                {
                    case (int)SocketCommand.SSEND_LIST_PLAYER:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            /*selectUserName.ServerMessage = data.Message;*/
                            selectUserName.saveUsername();
                            selectUserName.Hide();

                            selectOpponent.ServerFeedback = "";
                            selectOpponent.setUsername(selectUserName.UserName);
                            selectOpponent.setListUser(data.Message);
                            selectOpponent.Show();
                        }));
                      
                        break;
                    case (int)SocketCommand.SREP_NAME_INVALID:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            selectUserName.ServerMessage = "Tên không hợp lệ, mời chọn tên khác!!!";
                        }));
                        break;
                    case (int)SocketCommand.SSEND_CHALLENGE:
                        this.Invoke((MethodInvoker)(() =>
                        {

                            string message = "Bạn có challenge từ " + data.Message + ". Chiễn chứ?";
                            const string caption = "You have a new Challenge!";
                            var result = MessageBox.Show(message, caption,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                            // If the no button was pressed ...
                            if (result == DialogResult.No)
                            {
                                socket.Send(new SocketData((int)SocketCommand.CREP_CHALLENGE_DENY, data.Message));

                            }
                            else if (result == DialogResult.Yes)
                            {
                                socket.Send(new SocketData((int)SocketCommand.CREP_CHALLENGE_ACCEPT, data.Message));
                            }
                        }));
                        break;
                    case (int)SocketCommand.SNOTI_ORDER_FIRST:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            selectOpponent.Hide();
                            StartGame(0);
                        }));

                        break;
                    case (int)SocketCommand.SNOTI_ORDER_SECOND:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            selectOpponent.Hide();
                            StartGame(1);
                        }));

                        break;
                    case (int)SocketCommand.SFORW_CHALLENGE_DENY:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            selectOpponent.ServerFeedback = "Đối thủ không chấp nhận thách đấu !?!";
                        }));

                        break;
                    case (int)SocketCommand.SFORW_QUIT:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            MessageBox.Show("Đối thủ chạy cmr!");
                            selectOpponent.ServerFeedback = "";
                            socket.Send(new SocketData((int)SocketCommand.CSEND_NAME, selectUserName.UserName));
                        }));

                        break;
                    case (int)SocketCommand.SFORW_TURN:

                       this.Invoke((MethodInvoker)(() =>
                       {
                           DieuKhien.danhCoDoiThu(grp, data.Point.X, data.Point.Y);
                           DieuKhien.kiemTraChienThang(grp);
                           
                       }));

                        break;
                   case (int)SocketCommand.SFORW_WIN:
                        this.Invoke((MethodInvoker)(() => 
                        {
                          socket.Send(new SocketData((int)SocketCommand.CSEND_NAME, selectUserName.UserName));
                       }));
                       break; 

                    /*case (int)SocketCommand.NOTIFY:
                        MessageBox.Show(data.Message);
                        break;
                    case (int)SocketCommand.NEW_GAME:
                        *//*this.Invoke((MethodInvoker)(() =>
                        {
                            *//*NewGame();
                            pnlChessBoard.Enabled = false;*//*
                        }));*//*
                        break;
                    case (int)SocketCommand.UNDO:
                        *//*Undo();
                        prcbCoolDown.Value = 0;*//*
                        break;
                    case (int)SocketCommand.END_GAME:
                        MessageBox.Show("Đã 5 con trên 1 hàng");
                        break;
                    case (int)SocketCommand.TIME_OUT:
                        MessageBox.Show("Hết giờ");
                        break;
                    case (int)SocketCommand.QUIT:
                        *//*tmCoolDown.Stop();*//*
                        MessageBox.Show("Người chơi đã thoát");
                        break;*/
                    default:
                        Console.WriteLine("Data da deser ko process duoc : {0}", data.Command);
                        break;
                }
            }

            Listen();
        }


        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            if (DieuKhien.SanSang)
            {
                //vẽ bàn cờ
                DieuKhien.veBanCo(grp);
                //vẽ lại các quân cờ trong stack
                DieuKhien.veLaiQuanCo(grp);
            }
        }

        private void chơiVớiNgườiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selectUserName.UserName != "")
            {
                MessageBox.Show("Tên người dùng đã được đặt và không thể thay đổi!");
                return;
            }
            selectUserName.Show();

            return;

            /*pictureChuoi1.Image = global::CO_CARO_2.Properties.Resources.gif1edit;
            textGayBan.Text = "The battle has begun!!!";
            panelGayban.Visible = true;
            Delayed(3000, () => panelGayban.Visible = false);

            welcomeChuoi.Visible = false;
            pictureChuoi1.Visible = true;
            logo.Visible = true;

            DieuKhien.choiVoiNguoi(grp);
            

            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel*/
        }
        public void StartGame(int luotdi)
        {
            pictureChuoi1.Image = global::CO_CARO_2.Properties.Resources.gif1edit;
            textGayBan.Text = "Hi, " + selectUserName.UserName +  ". Good luck!!";
            panelGayban.Visible = true;
            Delayed(7000, () => panelGayban.Visible = false);

            welcomeChuoi.Visible = false;
            pictureChuoi1.Visible = true;
            logo.Visible = true;

            DieuKhien.choiVoiNguoi(grp, luotdi);


            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
        }

        public void Delayed(int delay, Action action)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, e) => {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (DieuKhien.SanSang)
            {
                //chơi với người
                if (DieuKhien.CheDoChoi == 1)
                {

                    //đánh cờ với tọa độ chuột khi lick vào panel bàn cờ
                    DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                    if(DieuKhien.kiemTraChienThang(grp)==true)
                    {
  
                        socket.Send(new SocketData((int)SocketCommand.CSEND_NAME, selectUserName.UserName));
                    }
                  
                    //sau khi đánh cờ thì kiểm tra chiến thắng luôn
               
                }
                //chơi với máy
                else
                {
                    //người chơi đánh
                    DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                    //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                    if (!DieuKhien.kiemTraChienThang(grp))
                    {
                        //máy đánh
                        DieuKhien.mayDanh(grp);
                        DieuKhien.kiemTraChienThang(grp);
                    }
                }
            }
        }

        private void chơiVớiMáyToolStripMenuItem_Click(object sender = null, EventArgs e = null)
        {
            pictureChuoi1.Image = global::CO_CARO_2.Properties.Resources.gif1edit;
            textGayBan.Text = "The battle has begun!!!";
            panelGayban.Visible = true;
            Delayed(3000, () => panelGayban.Visible = false);

            welcomeChuoi.Visible = false;
            pictureChuoi1.Visible = true;
            logo.Visible = true;

            DieuKhien.LuotDi = 1;
            DieuKhien.choiVoiMay(grp);

            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void luậtChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuatChoi.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bananas Caro Battle \nGroup: The Fellowship of Bananas \n","",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.GetType().ToString());

            //string selected = comboBox1.SelectedItem.ToString();
            ////MessageBox.Show(selected);
            //if (selected == "Person vs AI")
            //{
            //    groupBox1.Visible = true;
            //    //DieuKhien.LuotDi;
            //    chơiVớiMáyToolStripMenuItem_Click(sender, e);
            //}
            //else if (selected == "Person vs Person")
            //    chơiVớiNgườiToolStripMenuItem_Click(sender, e);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

       

        //private void newgame_Click(object sender, EventArgs e)
        //{
        //    if (avp_btn.Checked)
        //    {
        //        DieuKhien.LuotDi = 1;
        //        chơiVớiMáyToolStripMenuItem_Click(sender, e);
        //    }else if (pvp_btn.Checked)
        //        chơiVớiNgườiToolStripMenuItem_Click(sender, e);
        //}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fmCoCaro_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void chuoi1_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.undo(grp);
        }
    }
}
