using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CO_CARO_2
{
    public partial class SelectOpponent : Form
    {
        private SocketManager socket;
        private fmCoCaro parentForm;
        public SelectOpponent(fmCoCaro parentForm, SocketManager socket)
        {
            InitializeComponent();
            this.socket = socket;
            this.parentForm = parentForm;

        }
        public string ServerFeedback
        {
            get { return this.serverFeedback.Text; }
            set
            {
                this.serverFeedback.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (listUser.Items.Count == 0)
            {
                serverFeedback.Text = "Không có người chơi online, vui lòng thử lại sau!";
                
                return;
            }
            if (listUser.SelectedIndex == -1)
            {
                serverFeedback.Text = "Vui lòng chọn đối thủ!";
                return;
            }
            socket.Send(new SocketData((int)SocketCommand.CSEND_OPNAME, listUser.SelectedItem.ToString()));
            ;
        }
        public void setListUser(String str)
        {
            listUser.Items.Clear();
            
            string[] list = str.Split(' ');
            if(list.Length == 1 && list[0] == "")
            {
                serverFeedback.Text = "Không có người chơi nào khác online, bấm vào đây để thử tải lại !";
                return;
            }
            listUser.Items.Clear();
            listUser.Items.AddRange(list);

        }
        public void setUsername(String name)
        {
            usernameText.Text = name;
        }

        private void serverFeedback_Click(object sender, EventArgs e)
        {

            socket.Send(new SocketData((int)SocketCommand.CSEND_NAME, parentForm.selectUserName.UserName));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
