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
    public partial class SelectUserName : Form
    {
        private SocketManager socket;
        private string serverMessage = "";
        private string userName = "";
        private fmCoCaro parentForm;

        public string ServerMessage
        {
            get { return serverMessage; }
            set { 
                serverMessage = value;
                serverFeedback.Text = value;
            }
        }
      
        public string UserName
        {
            get { return userName; }
            /*set
            {
                userName = value;
            }*/
        }
        public SelectUserName(fmCoCaro parentForm, SocketManager socket)
        {
            InitializeComponent();
            this.socket = socket;
            this.parentForm = parentForm;
        }

        private void SelectUserName_Load(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == "")
            {
                serverFeedback.Text = "Vui lòng nhập tên người chơi của bạn.";
                return;
            }
            if (!socket.isConnected)
            {
                serverFeedback.Text = "Lỗi! Không tạo được kết nối đến server. Đang thử lại..";
                parentForm.ConnectServer();
                return;
            }
            socket.Send(new SocketData((int)SocketCommand.CSEND_NAME, usernameTextbox.Text));
        }
        public void saveUsername()
        {
            this.userName = usernameTextbox.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
