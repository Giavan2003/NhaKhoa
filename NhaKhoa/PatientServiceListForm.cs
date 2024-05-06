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
using System.Xml.Linq;

namespace NhaKhoa
{
    public partial class PatientServiceListForm : Form
    {
        public PatientServiceListForm()
        {
            InitializeComponent();
        }
        PATIENTS patients = new PATIENTS();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dENTALDataSet.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter.Fill(this.dENTALDataSet.Patients);

            SqlCommand command = new SqlCommand("SELECT * FROM Patients");
            //SqlCommand command = new SqlCommand("SELECT DISTINCT std.Id, std.fname, std.lname, std.bdate, std.gender, std.phone, std.email, std.address, std.picture, course.lable \r\nFROM std \r\nLEFT JOIN subject ON std.Id = subject.StudentId \r\nLEFT JOIN course ON subject.CourseId = course.Id;\r\n");
            guna2DataGridView1.ReadOnly = true;
            // xu ly hình anh, code co tham khao msdn
            DataGridViewImageColumn piccol = new DataGridViewImageColumn(); // doi tuong lam viec voi dang picture cua datagridview
            guna2DataGridView1.RowTemplate.Height = 80; // dong nay tham khao tren MSDN ngay 10/03/2019,co gian de pic dep, dang tim auto-size
            guna2DataGridView1.DataSource = patients.getPatients(command);
            imageDataGridViewImageColumn = (DataGridViewImageColumn)guna2DataGridView1.Columns[6];
            imageDataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            guna2DataGridView1.AllowUserToAddRows = false;
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // Lấy ID từ dòng được chọn trong DataGridView
            int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value);

            // Tạo một instance của ServicesForm và truyền ID vào constructor
            MainForm mainForm = this.ParentForm as MainForm;
            if (mainForm != null)
            {
                mainForm.container(new PatientServiceForm(id));
            }
            //Form2 servicesForm = new Form2(id);
            //servicesForm.ShowDialog();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim();
            DataTable table = patients.searchPatients(keyword);
            guna2DataGridView1.DataSource = table;
        }
    }
}
