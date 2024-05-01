﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void container(object _form)
        {

            if (guna2Panel3.Controls.Count > 0) guna2Panel3.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(fm);
            guna2Panel3.Tag = fm;
            fm.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            container(new EmployeesMangementForm());
        }

        private void bt_bacsi_Click(object sender, EventArgs e)
        {
            container(new DoctorManagementForm());
        }
    }
}
