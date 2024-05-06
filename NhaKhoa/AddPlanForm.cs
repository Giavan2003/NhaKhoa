using Guna.UI2.WinForms;
using NhaKhoa.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NhaKhoa
{
    public partial class AddPlanForm : Form
    {
        public event EventHandler PlanAdded;
        public int idpatinent;
        DateTime EndTime;
        DateTime StartTime;
        SERVICES service = new SERVICES();
        STATUS status = new STATUS();
        PLANSERVICES plan = new PLANSERVICES();
        MEDICINES medicines = new MEDICINES();
        DOCTORS doctors = new DOCTORS();
        APM apm = new APM();
        public AddPlanForm(int id)
        {
            InitializeComponent();
            this.idpatinent = id;
            guna2DateTimePicker1.Value = DateTime.Now;
        }
        private void FillComboBoxStart()
        {
            cbb_start.Items.Clear();
            DateTime startTime = DateTime.Today.AddHours(8); // Thời gian bắt đầu từ 8h sáng
            DateTime endTime = DateTime.Today.AddHours(17); // Thời gian kết thúc là 17h
            TimeSpan interval = TimeSpan.FromMinutes(30); // Khoảng thời gian là 30 phút

            while (startTime <= endTime)
            {
                cbb_start.Items.Add(startTime.ToString("hh:mm tt"));
                startTime = startTime.Add(interval);
            }
        }
        private void FillComboBoxTime()
        {
            cbb_thoigian.Items.Clear();
            cbb_thoigian.Items.Add("15 phút");
            cbb_thoigian.Items.Add("30 phút");
            cbb_thoigian.Items.Add("1 giờ");
            cbb_thoigian.Items.Add("2 giờ");
            cbb_thoigian.Items.Add("3 giờ");
            cbb_thoigian.Items.Add("4 giờ");
        }
        private void CalculateTime()
        {
            // Lấy ngày tháng năm từ DateTimePicker
            DateTime selectedDate = guna2DateTimePicker1.Value.Date;
            if (cbb_thoigian.SelectedItem != null && cbb_thoigian.SelectedItem != null)
            {

                // Lấy thời gian bắt đầu từ ComboBoxStart
                TimeSpan startTime = GetStartTime();

                // Lấy khoảng thời gian từ ComboBoxTime
                TimeSpan timeInterval = GetSelectedTimeInterval();

                // Tính toán thời gian kết thúc
                TimeSpan endTime = startTime.Add(timeInterval);

                // Kết hợp ngày và thời gian để tạo ra thời gian hoàn chỉnh
                StartTime = selectedDate + startTime;
                EndTime = selectedDate + endTime;

                // Hiển thị thời gian bắt đầu và kết thúc (ví dụ)
                MessageBox.Show($"Thời gian bắt đầu: {StartTime}\nThời gian kết thúc: {EndTime}");
            }
        }

        private TimeSpan GetStartTime()
        {
            // Lấy thời gian bắt đầu từ ComboBoxStart
            string startTimeString = cbb_start.SelectedItem.ToString();
            DateTime startTime = DateTime.ParseExact(startTimeString, "hh:mm tt", CultureInfo.InvariantCulture);
            return startTime.TimeOfDay; // Chỉ lấy phần thời gian trong ngày
        }

        private TimeSpan GetSelectedTimeInterval()
        {
            // Lấy khoảng thời gian từ ComboBoxTime
            string timeIntervalString = cbb_thoigian.SelectedItem.ToString().Split(' ')[0];
            string timeUnit = cbb_thoigian.SelectedItem.ToString().Split(' ')[1]; // Lấy đơn vị thời gian (phút hoặc giờ)
            int timeInterval = int.Parse(timeIntervalString); // Lấy số giờ hoặc phút từ chuỗi

            if (timeUnit.Equals("phút"))
            {
                // Nếu đơn vị thời gian là phút, trả về TimeSpan tính theo phút
                return TimeSpan.FromMinutes(timeInterval);
            }
            else if (timeUnit.Equals("giờ"))
            {
                // Nếu đơn vị thời gian là giờ, trả về TimeSpan tính theo giờ
                return TimeSpan.FromHours(timeInterval);
            }
            else
            {
                // Xử lý trường hợp khác ở đây nếu cần
                return TimeSpan.Zero; // Mặc định trả về TimeSpan.Zero nếu không thể xác định đơn vị thời gian
            }
        }



        private DateTime CalculateEndTime(DateTime startTime, TimeSpan timeInterval)
        {
            // Tính toán thời gian kết thúc bằng cách cộng thời gian bắt đầu và khoảng thời gian
            DateTime endTime = startTime.Add(timeInterval);
            return endTime;
        }
        private bool ValidateInputs()
        {
            // Kiểm tra xem các trường nhập liệu có được điền đầy đủ không
            if (string.IsNullOrWhiteSpace(txt_giatien.Text) ||
                string.IsNullOrWhiteSpace(txt_soluong.Text) ||
                string.IsNullOrWhiteSpace(txt_tongtien.Text) ||
                string.IsNullOrWhiteSpace(txt_giamgia.Text))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra xem giá, số lượng và tổng tiền có phải là số không
            if (!float.TryParse(txt_giatien.Text, out float price) ||
                !int.TryParse(txt_soluong.Text, out int quantity) ||
                !float.TryParse(txt_tongtien.Text, out float payment) ||
                !int.TryParse(txt_giamgia.Text, out int discount))
            {
                MessageBox.Show("Price, quantity, total, and discount must be numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số lượng và giảm giá không được âm
            if (quantity <= 0 || discount < 0)
            {
                MessageBox.Show("Quantity and discount must be greater than zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra giảm giá không vượt quá 100
            if (discount >= 100)
            {
                MessageBox.Show("Discount must be less than 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ShowSuccessMessage()
        {
            MessageBox.Show("Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;
            int serviceID = (int)cbb_dichvu.SelectedValue;
            int doctorId = (int)cbb_bacsi.SelectedValue;
            int patientID = idpatinent;
            DateTime planDate = guna2DateTimePicker1.Value;
            float price = Convert.ToSingle(txt_giatien.Text);
            int statusID = (int)cbb_trangthai.SelectedValue;
            int quantity = Convert.ToInt32(txt_soluong.Text);
            float payment = Convert.ToSingle(txt_tongtien.Text);
            float discount = price* quantity - payment;
            if (guna2CustomRadioButton1.Checked)
            {
                DateTime selectedDate = guna2DateTimePicker1.Value.Date;
                string description = txt_ghichu.Text;

                string status = "Chưa hoàn thành ";
                if (!apm.IsAppointmentOverlapping(doctorId, StartTime, EndTime))
                {
                    plan.InsertTreatmentPlan(serviceID, patientID, quantity, planDate, statusID, price, doctorId, discount, payment, 0);
                    apm.InsertAppointment(idpatinent, doctorId, StartTime, EndTime, description, status);
                    ShowSuccessMessage();
                    load();
                    PlanAdded?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Lịch đã bị trùng  ", "Add appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                plan.InsertTreatmentPlan(serviceID, patientID, quantity, planDate, statusID, price, null, discount, payment, 0);
                ShowSuccessMessage();
                load();
                PlanAdded?.Invoke(this, EventArgs.Empty);
            }

        }

        private void AddPlanForm_Load(object sender, EventArgs e)
        {
            FillComboBoxStart();
            FillComboBoxTime();
            DataTable serviceData = service.getService();
            if (serviceData.Rows.Count > 0)
            {
                // Hiển thị dữ liệu dịch vụ trong combobox guna2ComboBox1
                cbb_dichvu.DataSource = serviceData;
                cbb_dichvu.DisplayMember = "Name";
                cbb_dichvu.ValueMember = "ServiceID";
                cbb_trangthai.DataSource = status.getStatus();
                cbb_trangthai.DisplayMember = "Name";
                cbb_trangthai.ValueMember = "Id";
                cbb_bacsi.DataSource = doctors.getDoctor2();
                cbb_bacsi.ValueMember = "DoctorID";
                cbb_bacsi.DisplayMember = "FullName";
                // Lấy giá từ dữ liệu dịch vụ và hiển thị trong textbox txt_price1
                // Ở đây, giả sử giá của dịch vụ đầu tiên được chọn
                UpdatePrice();

                // Khi combobox thay đổi lựa chọn, cập nhật giá
                cbb_dichvu.SelectedIndexChanged += cbb_dichvu_SelectedIndexChanged;

            }
        }
        private void load()
        {
            // Đặt lại các giá trị của các điều khiển trên form về giá trị mặc định ban đầu
            cbb_dichvu.SelectedIndex = -1; // Chọn mục đầu tiên trong combobox dịch vụ
            cbb_trangthai.SelectedIndex = -1; // Chọn mục đầu tiên trong combobox trạng thái
            cbb_bacsi.SelectedIndex = -1; // Chọn mục đầu tiên trong combobox bác sĩ
            txt_giatien.Text = ""; // Xóa văn bản từ textbox giá tiền
            txt_soluong.Text = ""; // Xóa văn bản từ textbox số lượng
            txt_tongtien.Text = ""; // Xóa văn bản từ textbox tổng tiền
            txt_giamgia.Text = ""; // Xóa văn bản từ textbox giảm giá
            txt_ghichu.Text = ""; // Xóa văn bản từ textbox ghi chú
            guna2CustomRadioButton1.Checked = false; // Bỏ chọn radio button

            // Đặt lại các giá trị của các biến hoặc thuộc tính
            StartTime = DateTime.MinValue; // Đặt lại thời gian bắt đầu
            EndTime = DateTime.MinValue; // Đặt lại thời gian kết thúc
        }

        private void UpdatePrice()
        {
            // Lấy dữ liệu dịch vụ từ combobox
            DataRowView selectedServiceRow = (DataRowView)cbb_dichvu.SelectedItem;
            if (selectedServiceRow != null)
            {
                int price = Convert.ToInt32(selectedServiceRow["Price"]);
                txt_giatien.Text = price.ToString();
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
                        txt_tongtien.Text = txt_giatien.Text;
                    }
                }
                else if (int.TryParse(txt_soluong.Text, out total))
                {
                    int discountedPrice = price * total;
                    txt_tongtien.Text = discountedPrice.ToString();
                }
            }
        }

        private void cbb_trangthai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_dichvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void txt_giamgia_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void cbb_start_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTime();
        }

        private void cbb_thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTime();
        }
    }
}
