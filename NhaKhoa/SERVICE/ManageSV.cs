using NhaKhoa.MEDICINE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa.SERVICE
{
    public partial class ManageSV : Form
    {
        public ManageSV()
        {
            InitializeComponent();
        }
        Services sv = new Services();

        private void ManageSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dENTALDataSet6.Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.dENTALDataSet6.Services);
            ComboBoxUnit.Items.Add("Lần ");
            ComboBoxUnit.Items.Add("Răng");
            ComboBoxUnit.Items.Add("Hàm");
            

            // Chọn mặc định là "Viên" hoặc giá trị khác nếu cần
            ComboBoxUnit.SelectedItem = "Lần";
            LoadSVData();
        }
        private void LoadSVData()
        {
            // Lấy dữ liệu từ database và hiển thị lên DataGridView
            DataTable table = sv.GetAllServices();
            guna2DataGridView1.DataSource = table;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string unit = ComboBoxUnit.SelectedItem.ToString();
            float price = Convert.ToSingle(txtPrice.Text.Trim());
            string description = txtdesc.Text.Trim();

            // Thêm dịch vụ vào database
            if (sv.InsertService(name, unit,  price,description))
            {
                MessageBox.Show("Service added successfully.", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSVData(); // Refresh lại dữ liệu sau khi thêm
            }
            else
            {
                MessageBox.Show("Failed to add service.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            int serviceId = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["ServiceIDDataGridViewTextBoxColumn"].Value);
            string name = txtName.Text.Trim();
            string unit = ComboBoxUnit.SelectedItem.ToString();
            float price = Convert.ToSingle(txtPrice.Text.Trim());
            string description = txtdesc.Text.Trim();

            // Cập nhật thông tin dịch vụ trong database
            if (sv.UpdateService(serviceId, name, unit,  price,description))
            {
                MessageBox.Show("Service updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSVData(); // Refresh lại dữ liệu sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Failed to update service.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID của dịch vụ cần xóa từ DataGridView
                int serviceId = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["serviceIDDataGridViewTextBoxColumn"].Value);

                // Hiển thị thông báo xác nhận xóa
                DialogResult result = MessageBox.Show("Are you sure you want to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Xóa dịch vụ nếu người dùng xác nhận
                if (result == DialogResult.Yes)
                {
                    if (sv.DeleteService(serviceId))
                    {
                        MessageBox.Show("Service deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSVData(); // Refresh lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete service.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "";
            ComboBoxUnit.SelectedIndex = -1;
            txtdesc.Text = "";
            LoadSVData();

        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            LoadSVData();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            DataTable table = sv.SearchServices(keyword);
            guna2DataGridView1.DataSource = table;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy chỉ số của hàng được chọn
                int rowIndex = e.RowIndex;

                // Lấy giá trị từ các cột tương ứng và điền vào các điều khiển trên form
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[rowIndex];
                txtName.Text = selectedRow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                ComboBoxUnit.SelectedItem = selectedRow.Cells["unitDataGridViewTextBoxColumn"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["priceDataGridViewTextBoxColumn"].Value.ToString();
                txtdesc.Text = selectedRow.Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString();
            }
        }
    }
}
