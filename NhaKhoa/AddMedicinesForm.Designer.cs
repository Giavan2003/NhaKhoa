namespace NhaKhoa
{
    partial class AddMedicinesForm
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
            this.combobox_bskedon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_thuoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_gia = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_soluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_tongtien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_giamgia = new Guna.UI2.WinForms.Guna2TextBox();
            this.bt_add = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tên bác sĩ";
            // 
            // combobox_bskedon
            // 
            this.combobox_bskedon.BackColor = System.Drawing.Color.Transparent;
            this.combobox_bskedon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_bskedon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_bskedon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_bskedon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_bskedon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.combobox_bskedon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.combobox_bskedon.ItemHeight = 30;
            this.combobox_bskedon.Location = new System.Drawing.Point(160, 49);
            this.combobox_bskedon.Name = "combobox_bskedon";
            this.combobox_bskedon.Size = new System.Drawing.Size(236, 36);
            this.combobox_bskedon.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Loại thuốc";
            // 
            // cbb_thuoc
            // 
            this.cbb_thuoc.BackColor = System.Drawing.Color.Transparent;
            this.cbb_thuoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_thuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_thuoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_thuoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_thuoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_thuoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_thuoc.ItemHeight = 30;
            this.cbb_thuoc.Location = new System.Drawing.Point(160, 125);
            this.cbb_thuoc.Name = "cbb_thuoc";
            this.cbb_thuoc.Size = new System.Drawing.Size(236, 36);
            this.cbb_thuoc.TabIndex = 20;
            this.cbb_thuoc.SelectedIndexChanged += new System.EventHandler(this.cbb_thuoc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Giá";
            // 
            // txt_gia
            // 
            this.txt_gia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_gia.DefaultText = "";
            this.txt_gia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_gia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_gia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_gia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gia.Location = new System.Drawing.Point(160, 197);
            this.txt_gia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.PasswordChar = '\0';
            this.txt_gia.PlaceholderText = "";
            this.txt_gia.SelectedText = "";
            this.txt_gia.Size = new System.Drawing.Size(220, 44);
            this.txt_gia.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Số lượng";
            // 
            // txt_soluong
            // 
            this.txt_soluong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_soluong.DefaultText = "";
            this.txt_soluong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_soluong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_soluong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_soluong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_soluong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_soluong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_soluong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_soluong.Location = new System.Drawing.Point(528, 198);
            this.txt_soluong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.PasswordChar = '\0';
            this.txt_soluong.PlaceholderText = "";
            this.txt_soluong.SelectedText = "";
            this.txt_soluong.Size = new System.Drawing.Size(220, 43);
            this.txt_soluong.TabIndex = 24;
            this.txt_soluong.TextChanged += new System.EventHandler(this.txt_soluong_TextChanged);
            // 
            // txt_tongtien
            // 
            this.txt_tongtien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_tongtien.DefaultText = "";
            this.txt_tongtien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_tongtien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_tongtien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_tongtien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_tongtien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_tongtien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_tongtien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_tongtien.Location = new System.Drawing.Point(528, 286);
            this.txt_tongtien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_tongtien.Name = "txt_tongtien";
            this.txt_tongtien.PasswordChar = '\0';
            this.txt_tongtien.PlaceholderText = "";
            this.txt_tongtien.SelectedText = "";
            this.txt_tongtien.Size = new System.Drawing.Size(220, 44);
            this.txt_tongtien.TabIndex = 25;
            this.txt_tongtien.TextChanged += new System.EventHandler(this.txt_tongtien_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Tổng tiền";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Giảm giá(%)";
            // 
            // txt_giamgia
            // 
            this.txt_giamgia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giamgia.DefaultText = "";
            this.txt_giamgia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_giamgia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_giamgia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giamgia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giamgia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giamgia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_giamgia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giamgia.Location = new System.Drawing.Point(160, 286);
            this.txt_giamgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_giamgia.Name = "txt_giamgia";
            this.txt_giamgia.PasswordChar = '\0';
            this.txt_giamgia.PlaceholderText = "";
            this.txt_giamgia.SelectedText = "";
            this.txt_giamgia.Size = new System.Drawing.Size(220, 44);
            this.txt_giamgia.TabIndex = 28;
            this.txt_giamgia.TextChanged += new System.EventHandler(this.txt_giamgia_TextChanged);
            // 
            // bt_add
            // 
            this.bt_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bt_add.ForeColor = System.Drawing.Color.White;
            this.bt_add.Location = new System.Drawing.Point(238, 386);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(210, 61);
            this.bt_add.TabIndex = 29;
            this.bt_add.Text = "Thêm";
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // AddMedicinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.txt_giamgia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_tongtien);
            this.Controls.Add(this.txt_soluong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_gia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_thuoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combobox_bskedon);
            this.Controls.Add(this.label1);
            this.Name = "AddMedicinesForm";
            this.Text = "AddMedicinesForm";
            this.Load += new System.EventHandler(this.AddMedicinesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_bskedon;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_thuoc;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_gia;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_soluong;
        private Guna.UI2.WinForms.Guna2TextBox txt_tongtien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txt_giamgia;
        private Guna.UI2.WinForms.Guna2Button bt_add;
    }
}