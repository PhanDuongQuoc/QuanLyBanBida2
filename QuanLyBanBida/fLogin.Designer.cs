
namespace QuanLyBanBida
{
    partial class fLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_NameID = new System.Windows.Forms.TextBox();
            this.lbl_NameID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_Exit);
            this.panel1.Controls.Add(this.btn_Login);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 468);
            this.panel1.TabIndex = 0;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Exit.Location = new System.Drawing.Point(349, 381);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(120, 60);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click_1);
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(51, 381);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(120, 60);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "Đăng Nhập";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_Password);
            this.panel3.Controls.Add(this.lbl_Password);
            this.panel3.Location = new System.Drawing.Point(44, 299);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 70);
            this.panel3.TabIndex = 2;
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_Password.Location = new System.Drawing.Point(175, 12);
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(250, 40);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Password.Location = new System.Drawing.Point(49, 21);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(106, 23);
            this.lbl_Password.TabIndex = 0;
            this.lbl_Password.Text = "Mật Khẩu: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_NameID);
            this.panel2.Controls.Add(this.lbl_NameID);
            this.panel2.Location = new System.Drawing.Point(44, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 70);
            this.panel2.TabIndex = 0;
            // 
            // txt_NameID
            // 
            this.txt_NameID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NameID.Location = new System.Drawing.Point(175, 16);
            this.txt_NameID.Multiline = true;
            this.txt_NameID.Name = "txt_NameID";
            this.txt_NameID.Size = new System.Drawing.Size(250, 40);
            this.txt_NameID.TabIndex = 1;
            // 
            // lbl_NameID
            // 
            this.lbl_NameID.AutoSize = true;
            this.lbl_NameID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NameID.Location = new System.Drawing.Point(3, 24);
            this.lbl_NameID.Name = "lbl_NameID";
            this.lbl_NameID.Size = new System.Drawing.Size(152, 23);
            this.lbl_NameID.TabIndex = 0;
            this.lbl_NameID.Text = "Tên Đăng Nhập: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyBanBida.Properties.Resources.user;
            this.pictureBox1.Image = global::QuanLyBanBida.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(203, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 126);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // fLogin
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 491);
            this.Controls.Add(this.panel1);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_NameID;
        private System.Windows.Forms.Label lbl_NameID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

