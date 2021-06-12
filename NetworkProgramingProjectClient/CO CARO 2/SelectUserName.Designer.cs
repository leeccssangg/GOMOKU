namespace CO_CARO_2
{
    partial class SelectUserName
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.serverFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = global::CO_CARO_2.Properties.Resources.icon1;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 202);
            this.label1.TabIndex = 8;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(391, 126);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(185, 29);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "Tên người chơi: ";
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(597, 125);
            this.usernameTextbox.Multiline = true;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(177, 37);
            this.usernameTextbox.TabIndex = 10;
            this.usernameTextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Location = new System.Drawing.Point(644, 236);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(130, 33);
            this.submit.TabIndex = 11;
            this.submit.Text = "Xác nhận";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // serverFeedback
            // 
            this.serverFeedback.AutoSize = true;
            this.serverFeedback.BackColor = System.Drawing.Color.Transparent;
            this.serverFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverFeedback.ForeColor = System.Drawing.Color.Red;
            this.serverFeedback.Location = new System.Drawing.Point(401, 202);
            this.serverFeedback.Name = "serverFeedback";
            this.serverFeedback.Size = new System.Drawing.Size(0, 20);
            this.serverFeedback.TabIndex = 12;
            this.serverFeedback.Click += new System.EventHandler(this.label2_Click);
            // 
            // SelectUserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 297);
            this.Controls.Add(this.serverFeedback);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SelectUserName";
            this.Text = "Chọn tên người chơi";
            this.Load += new System.EventHandler(this.SelectUserName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameLabel;
        protected System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label serverFeedback;
    }
}