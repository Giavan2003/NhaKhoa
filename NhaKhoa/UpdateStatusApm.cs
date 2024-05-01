using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa
{
    public partial class UpdateStatusApm : Form

    {
        DateTime startDate;
        public UpdateStatusApm(DateTime startdate ,string patientName, string description, string initialStatus)
        {
            InitializeComponent();
            startDate = startdate;

            // Hiển thị tên bệnh nhân và mô tả trong các TextBox
            tbPatientName.Text = patientName;
            tbDescription.Text = description;

            // Thiết lập trạng thái ban đầu cho các RadioButton
            SetInitialStatus(initialStatus);
        }
        MYDB mydb = new MYDB();
        private void SetInitialStatus(string initialStatus)
        {
            switch (initialStatus)
            {
                case "Chưa hoàn thành ":
                    rbIncomplete.Checked = true;
                    break;
                case "Đã hoàn thành ":
                    rbCompleted.Checked = true;
                    break;
                case "Đã bị hủy ":
                    rbCanceled.Checked = true;
                    break;
                default:
                    // Nếu trạng thái không hợp lệ, không chọn RadioButton nào
                    break;
            }
        }

        // Lấy trạng thái được chọn
        public string GetSelectedStatus()
        {
            if (rbIncomplete.Checked)
            {
                return "Chưa hoàn thành ";
            }
            else if (rbCompleted.Checked)
            {
                return "Đã hoàn thành ";
            }
            else if (rbCanceled.Checked)
            {
                return "Đã bị hủy ";
            }
            else
            {
                return ""; // Trường hợp không chọn trạng thái nào
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string selectedStatus = GetSelectedStatus();
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                // Lấy thông tin cần thiết từ các TextBox
                string patientName = tbPatientName.Text;
                string description = tbDescription.Text;

                // Thực hiện cập nhật trạng thái vào cơ sở dữ liệu
                if (UpdateAppointmentStatus(patientName, description, selectedStatus))
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Cập nhật trạng thái thành công!");
                    this.Close(); // Đóng form sau khi lưu thành công
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật trạng thái. Vui lòng thử lại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
            }
        }
        private bool UpdateAppointmentStatus(string patientName, string description, string status)
        {
            try
            {
                // Thực hiện kết nối cơ sở dữ liệu và cập nhật trạng thái
                
                    
                    SqlCommand command = new SqlCommand("UPDATE Appointments SET Status = @Status WHERE StartDateTime = @StartDateTime AND Description = @Description", mydb.getConnection);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@StartDateTime", startDate);
                    command.Parameters.AddWithValue("@Description", description);
                mydb.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                return false; 
            }
        }
    }
}
