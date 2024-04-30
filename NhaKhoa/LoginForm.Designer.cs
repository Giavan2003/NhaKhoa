namespace NhaKhoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txt_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.bt_Login = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.radiobt_dentist = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radiobt_staff = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radiobt_admin = new Guna.UI2.WinForms.Guna2RadioButton();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.AutoRoundedCorners = true;
            this.txt_username.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.txt_username.BorderRadius = 29;
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_username.DefaultText = "";
            this.txt_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Location = new System.Drawing.Point(543, 138);
            this.txt_username.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txt_username.Name = "txt_username";
            this.txt_username.PasswordChar = '\0';
            this.txt_username.PlaceholderText = "Username";
            this.txt_username.SelectedText = "";
            this.txt_username.Size = new System.Drawing.Size(336, 60);
            this.txt_username.TabIndex = 2;
            // 
            // txt_password
            // 
            this.txt_password.AutoRoundedCorners = true;
            this.txt_password.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.txt_password.BorderRadius = 29;
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_password.DefaultText = "";
            this.txt_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_password.ForeColor = System.Drawing.Color.Black;
            this.txt_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_password.Location = new System.Drawing.Point(543, 238);
            this.txt_password.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '●';
            this.txt_password.PlaceholderText = "Password";
            this.txt_password.SelectedText = "";
            this.txt_password.Size = new System.Drawing.Size(336, 60);
            this.txt_password.TabIndex = 3;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // bt_Login
            // 
            this.bt_Login.AutoRoundedCorners = true;
            this.bt_Login.BorderRadius = 31;
            this.bt_Login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_Login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_Login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_Login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_Login.FillColor = System.Drawing.Color.Navy;
            this.bt_Login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Login.ForeColor = System.Drawing.Color.White;
            this.bt_Login.Location = new System.Drawing.Point(579, 386);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(266, 65);
            this.bt_Login.TabIndex = 4;
            this.bt_Login.Text = "Login";
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::NhaKhoa.Properties.Resources.rang;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(416, 542);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(602, -28);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(202, 177);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 6;
            this.guna2PictureBox2.TabStop = false;
            // 
            // radiobt_dentist
            // 
            this.radiobt_dentist.AutoSize = true;
            this.radiobt_dentist.BackColor = System.Drawing.Color.Transparent;
            this.radiobt_dentist.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobt_dentist.CheckedState.BorderThickness = 0;
            this.radiobt_dentist.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobt_dentist.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radiobt_dentist.CheckedState.InnerOffset = -4;
            this.radiobt_dentist.Location = new System.Drawing.Point(668, 332);
            this.radiobt_dentist.Name = "radiobt_dentist";
            this.radiobt_dentist.Size = new System.Drawing.Size(85, 24);
            this.radiobt_dentist.TabIndex = 7;
            this.radiobt_dentist.Text = "Dentist";
            this.radiobt_dentist.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radiobt_dentist.UncheckedState.BorderThickness = 2;
            this.radiobt_dentist.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radiobt_dentist.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radiobt_dentist.UseVisualStyleBackColor = false;
            // 
            // radiobt_staff
            // 
            this.radiobt_staff.AutoSize = true;
            this.radiobt_staff.BackColor = System.Drawing.Color.Transparent;
            this.radiobt_staff.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobt_staff.CheckedState.BorderThickness = 0;
            this.radiobt_staff.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobt_staff.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radiobt_staff.CheckedState.InnerOffset = -4;
            this.radiobt_staff.Location = new System.Drawing.Point(543, 332);
            this.radiobt_staff.Name = "radiobt_staff";
            this.radiobt_staff.Size = new System.Drawing.Size(69, 24);
            this.radiobt_staff.TabIndex = 8;
            this.radiobt_staff.Text = "Staff";
            this.radiobt_staff.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radiobt_staff.UncheckedState.BorderThickness = 2;
            this.radiobt_staff.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radiobt_staff.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radiobt_staff.UseVisualStyleBackColor = false;
            // 
            // radiobt_admin
            // 
            this.radiobt_admin.AutoSize = true;
            this.radiobt_admin.BackColor = System.Drawing.Color.Transparent;
            this.radiobt_admin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobt_admin.CheckedState.BorderThickness = 0;
            this.radiobt_admin.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radiobt_admin.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radiobt_admin.CheckedState.InnerOffset = -4;
            this.radiobt_admin.Location = new System.Drawing.Point(800, 332);
            this.radiobt_admin.Name = "radiobt_admin";
            this.radiobt_admin.Size = new System.Drawing.Size(79, 24);
            this.radiobt_admin.TabIndex = 9;
            this.radiobt_admin.Text = "Admin";
            this.radiobt_admin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radiobt_admin.UncheckedState.BorderThickness = 2;
            this.radiobt_admin.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radiobt_admin.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radiobt_admin.UseVisualStyleBackColor = false;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(945, -2);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 31);
            this.guna2ControlBox1.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(987, 540);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.radiobt_admin);
            this.Controls.Add(this.radiobt_staff);
            this.Controls.Add(this.radiobt_dentist);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.bt_Login);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.guna2PictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_username;
        private Guna.UI2.WinForms.Guna2TextBox txt_password;
        private Guna.UI2.WinForms.Guna2Button bt_Login;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2RadioButton radiobt_dentist;
        private Guna.UI2.WinForms.Guna2RadioButton radiobt_staff;
        private Guna.UI2.WinForms.Guna2RadioButton radiobt_admin;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}


