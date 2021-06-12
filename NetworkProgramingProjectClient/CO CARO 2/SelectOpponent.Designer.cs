namespace CO_CARO_2
{
    partial class SelectOpponent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.Label();
            this.listUser = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverFeedback = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(21, 45);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(168, 25);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Tên người chơi: ";
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.usernameText.Location = new System.Drawing.Point(195, 45);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(0, 25);
            this.usernameText.TabIndex = 11;
            // 
            // listUser
            // 
            this.listUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listUser.FormattingEnabled = true;
            this.listUser.ItemHeight = 25;
            this.listUser.Location = new System.Drawing.Point(26, 147);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(223, 229);
            this.listUser.TabIndex = 12;
            this.listUser.Tag = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(283, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "Chọn đối thủ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = global::CO_CARO_2.Properties.Resources.icon1;
            this.label1.Location = new System.Drawing.Point(436, -8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 252);
            this.label1.TabIndex = 9;
            // 
            // serverFeedback
            // 
            this.serverFeedback.AutoSize = true;
            this.serverFeedback.BackColor = System.Drawing.Color.Transparent;
            this.serverFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverFeedback.ForeColor = System.Drawing.Color.Red;
            this.serverFeedback.Location = new System.Drawing.Point(279, 272);
            this.serverFeedback.Name = "serverFeedback";
            this.serverFeedback.Size = new System.Drawing.Size(0, 20);
            this.serverFeedback.TabIndex = 14;
            this.serverFeedback.Click += new System.EventHandler(this.serverFeedback_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Danh sách đối thủ:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // SelectOpponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverFeedback);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listUser);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label1);
            this.Name = "SelectOpponent";
            this.Text = "SelectOpponent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label serverFeedback;
        private System.Windows.Forms.Label label2;
    }
}