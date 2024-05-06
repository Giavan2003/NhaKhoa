using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa.MEDICINE
{
    public partial class ManageMedicines : Form
    {
        public ManageMedicines()
        {
            InitializeComponent();
        }
        Medicines medicine = new Medicines();

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            LoadMedicinesData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ManageMedicines_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dENTALDataSet5.Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.dENTALDataSet5.Services);

            ComboBoxUnit.Items.Add("Viên");
            ComboBoxUnit.Items.Add("Gói");
            ComboBoxUnit.Items.Add("Hộp");
            ComboBoxUnit.Items.Add("Chai");
            ComboBoxUnit.Items.Add("Tuýp");

            // Chọn mặc định là "Viên" hoặc giá trị khác nếu cần
            ComboBoxUnit.SelectedItem = "Viên";
            LoadMedicinesData();

        }
        private void LoadMedicinesData()
        {
            // Lấy dữ liệu từ database và hiển thị lên DataGridView
            DataTable table = medicine.GetAllMedicines();
            guna2DataGridView1.DataSource = table;
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {

            int medicineId = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["MedicineIDDataGridViewTextBoxColumn"].Value);
            string name = txtName.Text.Trim();
            string unit = ComboBoxUnit.SelectedItem.ToString();
            float price = Convert.ToSingle(txtPrice.Text.Trim());
            string description = txtdesc.Text.Trim();

            // Cập nhật thông tin thuốc trong database
            if (medicine.UpdateMedicine(medicineId, name, unit, description,price))
            {
                MessageBox.Show("Medicine updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMedicinesData(); // Refresh lại dữ liệu sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Failed to update medicine.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID của thuốc cần xóa từ DataGridView
                int medicineId = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["MedicineIDDataGridViewTextBoxColumn"].Value);

                // Hiển thị thông báo xác nhận xóa
                DialogResult result = MessageBox.Show("Are you sure you want to delete this medicine?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Xóa thuốc nếu người dùng xác nhận
                if (result == DialogResult.Yes)
                {
                    if (medicine.DeleteMedicine(medicineId))
                    {
                        MessageBox.Show("Medicine deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicinesData(); // Refresh lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete medicine.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadMedicinesData();

        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            DataTable table = medicine.SearchMedicines(keyword);
            guna2DataGridView1.DataSource = table;

        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string unit = ComboBoxUnit.SelectedItem.ToString();
            float price = Convert.ToSingle(txtPrice.Text.Trim());
            string description = txtdesc.Text.Trim();

            // Thêm thuốc vào database
            if (medicine.InsertMedicine(name, unit,  description,price))
            {
                MessageBox.Show("Medicine added successfully.", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMedicinesData(); // Refresh lại dữ liệu sau khi thêm
            }
            else
            {
                MessageBox.Show("Failed to add medicine.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
