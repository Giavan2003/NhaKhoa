namespace NhaKhoa.Appointments
{
    partial class ShowAppointment
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
            this.btntoday = new Guna.UI2.WinForms.Guna2Button();
            this.btntomorow = new Guna.UI2.WinForms.Guna2Button();
            this.DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.yourPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.scrollablePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // btntoday
            // 
            this.btntoday.BorderRadius = 15;
            this.btntoday.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btntoday.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btntoday.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btntoday.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btntoday.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btntoday.FillColor = System.Drawing.Color.Turquoise;
            this.btntoday.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btntoday.ForeColor = System.Drawing.Color.White;
            this.btntoday.Location = new System.Drawing.Point(31, 15);
            this.btntoday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btntoday.Name = "btntoday";
            this.btntoday.Size = new System.Drawing.Size(143, 39);
            this.btntoday.TabIndex = 0;
            this.btntoday.Text = "Hôm Nay ";
            this.btntoday.Click += new System.EventHandler(this.btntoday_Click);
            // 
            // btntomorow
            // 
            this.btntomorow.BorderRadius = 15;
            this.btntomorow.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btntomorow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btntomorow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btntomorow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btntomorow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btntomorow.FillColor = System.Drawing.Color.Turquoise;
            this.btntomorow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btntomorow.ForeColor = System.Drawing.Color.White;
            this.btntomorow.Location = new System.Drawing.Point(201, 15);
            this.btntomorow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btntomorow.Name = "btntomorow";
            this.btntomorow.Size = new System.Drawing.Size(143, 39);
            this.btntomorow.TabIndex = 1;
            this.btntomorow.Text = "Ngày Mai ";
            this.btntomorow.Click += new System.EventHandler(this.btntomorow_Click);
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.BorderRadius = 10;
            this.DateTimePicker1.Checked = true;
            this.DateTimePicker1.FillColor = System.Drawing.Color.Cyan;
            this.DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DateTimePicker1.Location = new System.Drawing.Point(391, 15);
            this.DateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(323, 44);
            this.DateTimePicker1.TabIndex = 2;
            this.DateTimePicker1.Value = new System.DateTime(2024, 4, 30, 19, 7, 56, 377);
            this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // yourPanel
            // 
            this.yourPanel.Location = new System.Drawing.Point(16, 87);
            this.yourPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yourPanel.Name = "yourPanel";
            this.yourPanel.Size = new System.Drawing.Size(1028, 724);
            this.yourPanel.TabIndex = 3;
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.scrollablePanel.Location = new System.Drawing.Point(16, 87);
            this.scrollablePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(1125, 455);
            this.scrollablePanel.TabIndex = 4;
            // 
            // ShowAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2035, 1184);
            this.Controls.Add(this.scrollablePanel);
            this.Controls.Add(this.yourPanel);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.btntomorow);
            this.Controls.Add(this.btntoday);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShowAppointment";
            this.Text = "ShowAppointment";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btntoday;
        private Guna.UI2.WinForms.Guna2Button btntomorow;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePicker1;
        private Guna.UI2.WinForms.Guna2Panel yourPanel;
        private Guna.UI2.WinForms.Guna2Panel scrollablePanel;
    }
}