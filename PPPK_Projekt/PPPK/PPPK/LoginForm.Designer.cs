
namespace PPPK
{
    partial class LoginForm
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
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.Location = new System.Drawing.Point(162, 256);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(146, 30);
            this.BtnLogIn.TabIndex = 13;
            this.BtnLogIn.Text = "Log in";
            this.BtnLogIn.UseVisualStyleBackColor = true;
            this.BtnLogIn.Click += new System.EventHandler(this.btnLogin);
            // 
            // TbPassword
            // 
            this.TbPassword.Location = new System.Drawing.Point(162, 207);
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.Size = new System.Drawing.Size(146, 20);
            this.TbPassword.TabIndex = 12;
            this.TbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // TbUserName
            // 
            this.TbUserName.Location = new System.Drawing.Point(162, 140);
            this.TbUserName.Name = "TbUserName";
            this.TbUserName.Size = new System.Drawing.Size(146, 20);
            this.TbUserName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username";
            // 
            // TbServer
            // 
            this.TbServer.Location = new System.Drawing.Point(162, 76);
            this.TbServer.Name = "TbServer";
            this.TbServer.Size = new System.Drawing.Size(146, 20);
            this.TbServer.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server";
            // 
            // LbError
            // 
            this.LbError.AutoSize = true;
            this.LbError.ForeColor = System.Drawing.Color.Crimson;
            this.LbError.Location = new System.Drawing.Point(100, 318);
            this.LbError.Name = "LbError";
            this.LbError.Size = new System.Drawing.Size(0, 13);
            this.LbError.TabIndex = 14;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.BtnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 363);
            this.Controls.Add(this.LbError);
            this.Controls.Add(this.BtnLogIn);
            this.Controls.Add(this.TbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbServer);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogIn;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbError;
    }
}