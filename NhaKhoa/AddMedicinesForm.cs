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

namespace NhaKhoa
{
    public partial class AddMedicinesForm : Form
    {
        public event EventHandler PlanAdded;
        private int patientid;
        SERVICES service = new SERVICES();
        STATUS status = new STATUS();
        PLANSERVICES plan = new PLANSERVICES();
        MEDICINES medicines = new MEDICINES();
        DOCTORS doctors = new DOCTORS();
        public AddMedicinesForm(int patientid)
        {
            InitializeComponent();
            this.patientid = patientid;
        }
        private void ResetTextBoxes()
        {

            // Xóa nội dung của các textbox
            txt_gia.Text = "";
            txt_soluong.Text = "";
            txt_giamgia.Text = "";
            txt_tongtien.Text = "";
            combobox_bskedon.DataSource = plan.ShowPlan3(patientid);
            combobox_bskedon.ValueMember = "DoctorID";
            combobox_bskedon.DisplayMember = "DoctorName";
            cbb_thuoc.DataSource = medicines.getMedicines();
            cbb_thuoc.ValueMember = "MedicineID";
            cbb_thuoc.DisplayMember = "Name";
        }
        private void AddMedicinesForm_Load(object sender, EventArgs e)
        {
            combobox_bskedon.DataSource = plan.ShowPlan3(patientid);
            combobox_bskedon.ValueMember = "DoctorID";
            combobox_bskedon.DisplayMember = "DoctorName";
            cbb_thuoc.DataSource = medicines.getMedicines();
            cbb_thuoc.ValueMember = "MedicineID";
            cbb_thuoc.DisplayMember = "Name";
            UpdatePrice();

            // Khi combobox thay đổi lựa chọn, cập nhật giá
            cbb_thuoc.SelectedIndexChanged += cbb_thuoc_SelectedIndexChanged;
        }
        private void UpdatePrice()
        {
            // Lấy dữ liệu dịch vụ từ combobox
            DataRowView selectedServiceRow = (DataRowView)cbb_thuoc.SelectedItem;
            if (selectedServiceRow != null)
            {
                int price = Convert.ToInt32(selectedServiceRow["Price"]);
                txt_gia.Text = price.ToString();
                int total;
                // Kiểm tra nếu trường txt_discount không rỗng
                if (!string.IsNullOrEmpty(txt_giamgia.Text))
                {
                    int discount;
                    // Kiểm tra xem có thể chuyển đổi txt_discount thành số nguyên hay không
                    if (int.TryParse(txt_giamgia.Text, out discount) && int.TryParse(txt_soluong.Text, out total))
                    {
                        int discountedPrice = price * (100 - discount) / 100 * total;
                        txt_tongtien.Text = discountedPrice.ToString();
                    }
                    else
                    {
                        // Xử lý nếu không thể chuyển đổi thành số nguyên
                        // Ví dụ: Hiển thị thông báo lỗi hoặc xử lý khác
                        // Trong trường hợp này, tôi sẽ giữ nguyên giá trị của txt_discountedPrice
                        txt_tongtien.Text = txt_gia.Text;
                    }
                }
                else if (int.TryParse(txt_soluong.Text, out total))
                {
                    int discountedPrice = price * total;
                    txt_tongtien.Text = discountedPrice.ToString();
                }
            }
        }


        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void txt_giamgia_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void txt_tongtien_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void cbb_thuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txt_gia.Text) ||
                string.IsNullOrWhiteSpace(txt_soluong.Text) ||
                string.IsNullOrWhiteSpace(txt_tongtien.Text))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!float.TryParse(txt_gia.Text, out float price) ||
                !int.TryParse(txt_soluong.Text, out int quantity) ||
                !float.TryParse(txt_tongtien.Text, out float payment))
            {
                MessageBox.Show("Price, quantity, and total must be numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (price <= 0 || quantity <= 0 || payment <= 0)
            {
                MessageBox.Show("Price, quantity, and payment must be greater than zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (payment < 0 || payment >= 100)
            {
                MessageBox.Show("Discount must be between 0 and 99.99", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Additional conditions can be checked depending on requirements

            return true;
        }

        // Success message function
        private void ShowSuccessMessage()
        {
            MessageBox.Show("Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            // Validate inputs before adding
            if (!ValidateInputs())
                return;

            int medicineID = (int)cbb_thuoc.SelectedValue;
            int doctorId = (int)combobox_bskedon.SelectedValue;
            int patientID = patientid;
            float price = Convert.ToSingle(txt_gia.Text);
            int quantity = Convert.ToInt32(txt_soluong.Text);
            float payment = Convert.ToSingle(txt_tongtien.Text);
            float discount = price * quantity - payment;
            medicines.InsertPatientsMedicines(patientID, medicineID, quantity, doctorId, payment, discount, price, 0);

            // Show success message
            ShowSuccessMessage();

            // Reset textboxes after adding
            ResetTextBoxes();

            // Trigger PlanAdded event
            PlanAdded?.Invoke(this, EventArgs.Empty);
        }
    }
}
