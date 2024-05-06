using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NhaKhoa.Appointments
{
    public partial class ApmForDoctor : Form
    {
        int DoctorID;
        private DateTime selectedDate;
        public ApmForDoctor(int doctorsID)
        {
            DateTimePicker1.Value = DateTime.Now;
            InitializeComponent();
            DoctorID = doctorsID;
        }
        MYDB mydb = new MYDB();
        APM apm = new APM();
        DateTime EndTime;
        DateTime StartTime;
        public DataTable getNameDogtors(int ID )
        {
            SqlCommand command = new SqlCommand("SELECT FullName FROM Doctors where DoctorID = @DoctorID", mydb.getConnection);
            command.Parameters.AddWithValue("@DoctorID", ID);
            return executeQuery(command);
        }
        private void FillTextboxBoxBS()
        {
            DataTable doctorNameTable = getNameDogtors(DoctorID);
            if (doctorNameTable.Rows.Count > 0)
            {
                DataRow row = doctorNameTable.Rows[0];
                string doctorName = row["FullName"].ToString();
                guna2TextBox1.Text = doctorName;
            }
        }
        private void FillComboBoxStart()
        {
            comboBoxStart.Items.Clear();
            DateTime startTime = DateTime.Today.AddHours(8); // Thời gian bắt đầu từ 8h sáng
            DateTime endTime = DateTime.Today.AddHours(17); // Thời gian kết thúc là 17h
            TimeSpan interval = TimeSpan.FromMinutes(30); // Khoảng thời gian là 30 phút

            while (startTime <= endTime)
            {
                comboBoxStart.Items.Add(startTime.ToString("hh:mm tt"));
                startTime = startTime.Add(interval);
            }
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public DataTable getAllPatients()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Patients", mydb.getConnection);
            return executeQuery(command);
        }
        private DataTable executeQuery(SqlCommand command)
        {
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            mydb.closeConnection();

            return table;
        }


        private void FillComboBoxTime()
        {
            comboBoxTime.Items.Clear();
            comboBoxTime.Items.Add("15 phút");
            comboBoxTime.Items.Add("30 phút");
            comboBoxTime.Items.Add("1 giờ");
            comboBoxTime.Items.Add("2 giờ");
            comboBoxTime.Items.Add("3 giờ");
            comboBoxTime.Items.Add("4 giờ");
        }
        private void FillComboBoxBN()
        {
            ComboBoxBN.DataSource = getAllPatients();
            ComboBoxBN.DisplayMember = "FullName";
            ComboBoxBN.ValueMember = "PatientID";
            ComboBoxBN.SelectedItem = null;
        }


        private void CalculateTime()
        {

            if (comboBoxStart.SelectedItem != null && comboBoxTime.SelectedItem != null)
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


            }
        }

        private TimeSpan GetStartTime()
        {
            // Lấy thời gian bắt đầu từ ComboBoxStart
            string startTimeString = comboBoxStart.SelectedItem.ToString();
            DateTime startTime = DateTime.ParseExact(startTimeString, "hh:mm tt", CultureInfo.InvariantCulture);
            return startTime.TimeOfDay; // Chỉ lấy phần thời gian trong ngày
        }

        private TimeSpan GetSelectedTimeInterval()
        {
            // Lấy khoảng thời gian từ ComboBoxTime
            string timeIntervalString = comboBoxTime.SelectedItem.ToString().Split(' ')[0];
            string timeUnit = comboBoxTime.SelectedItem.ToString().Split(' ')[1]; // Lấy đơn vị thời gian (phút hoặc giờ)
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.selectedDate = DateTimePicker1.Value.Date;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTimePicker1.Value.Date;
            
            int PatientID = (int)ComboBoxBN.SelectedValue;
            string description = TextBoxdesc.Text;

            string status = "Chưa hoàn thành ";
            if (!apm.IsAppointmentOverlapping(DoctorID, StartTime, EndTime))
            {
                apm.InsertAppointment(PatientID, DoctorID, StartTime, EndTime, description, status);
                MessageBox.Show("Thành công ", "Add appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lịch đã bị trùng  ", "Add appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTime();
        }

        private void comboBoxStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTime();

        }

        private void ComboBoxBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTime();

        }
    }
}
