using System;
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
    public partial class ServicesForm : Form
    {
        private int ServiceId;
        public ServicesForm(int id)
        {
            InitializeComponent();
            ServiceId = id;
        }
        PLANSERVICES plan = new PLANSERVICES();
        private void ServicesForm_Load(object sender, EventArgs e)
        {

            // Đổ dữ liệu vào các cột
            DataTable dt = plan.ShowPlan(ServiceId);
            guna2DataGridView1.DataSource = dt;
            // Thêm một cột DataGridViewButtonColumn
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Sửa";
            editButtonColumn.Name = "EditButtonColumn";
            editButtonColumn.Text = "Sửa";
            editButtonColumn.UseColumnTextForButtonValue = true;
            guna2DataGridView1.Columns.Add(editButtonColumn);
        }

    }
}
