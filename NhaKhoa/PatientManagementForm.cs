using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa
{
    public partial class PatientManagementForm : Form
    {
        public PatientManagementForm()
        {
            InitializeComponent();
        }
        PATIENTS patients = new PATIENTS();
        MYDB mydb = new MYDB();
        private void PatientManagementForm_Load(object sender, EventArgs e)
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

        private void bt_add_Click(object sender, EventArgs e)
        {
            PATIENTS patients = new PATIENTS();
            string fname = txt_fullname.Text;
            DateTime bdate = guna2DateTimePicker1.Value;
            string phone = txt_phone.Text;
            string adrs = txt_address.Text;
            string gender = "Male";

            if (radiobt_female.Checked)
            {
                gender = "Female";
            }

            MemoryStream imageStream = new MemoryStream();
            int born_year = guna2DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            // Kiểm tra tuổi hợp lệ của sinh viên
            if (((this_year - born_year) < 5) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Patient Age Must Be Between 5 and 100 years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsStringValid(fname))
            {
                MessageBox.Show("Full name cannot contain numeric characters", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!IsStringValid(fname) || !IsNumeric(phone) || phone.Length != 10)
            {
                MessageBox.Show("Invalid input. Please check the provided information.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                guna2PictureBox1.Image.Save(imageStream, ImageFormat.Png);
                byte[] imageBytes = imageStream.ToArray();
                //guna2PictureBox1.Image.Save(image, guna2PictureBox1.Image.RawFormat);
                if (patients.InsertPatient(fname, adrs, phone, bdate, gender, imageBytes))
                {
                    MessageBox.Show("New Patient Added", "Add Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Patient", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Hàm kiểm tra xem một chuỗi có phải là số hay không
        bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        // Hàm kiểm tra xem chuỗi có chứa ký tự số hay không
        bool IsStringValid(string input)
        {
            return !input.Any(char.IsDigit);
        }

        // Hàm kiểm tra xem các trường nhập liệu có trống không hay không
        bool verif()
        {
            if ((txt_fullname.Text.Trim() == "")
                        || (txt_address.Text.Trim() == "")
                        || (txt_phone.Text.Trim() == "")
                        || (guna2PictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private CameraForm camera;
        private void bt_upload_Click(object sender, EventArgs e)
        {
            camera = new CameraForm(this);
            camera.ShowDialog();
        }
        public void SetImage(Image image)
        {
            guna2PictureBox1.Image = image;
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // thu tu cua cac cot: id fname Inane bdgdr phn adrs - pic
            txt_id.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fullname.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            guna2DateTimePicker1.Value = (DateTime)guna2DataGridView1.CurrentRow.Cells[4].Value;
            // gender
            if ((guna2DataGridView1.CurrentRow.Cells[5].Value.ToString().Trim() == "Male"))
            {
                radiobt_male.Checked = true;
            }
            else
            {
                radiobt_female.Checked = true;
            }
            txt_phone.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_address.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            // code xu ly hình anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])guna2DataGridView1.CurrentRow.Cells[6].Value;
            MemoryStream picture = new MemoryStream(pic);
            guna2PictureBox1.Image = Image.FromStream(picture);
            Show();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // thu tu cua cac cot: id fname Inane bdgdr phn adrs - pic
            txt_id.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fullname.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            guna2DateTimePicker1.Value = (DateTime)guna2DataGridView1.CurrentRow.Cells[4].Value;
            // gender
            if ((guna2DataGridView1.CurrentRow.Cells[5].Value.ToString().Trim() == "Male"))
            {
                radiobt_male.Checked = true;
            }
            else
            {
                radiobt_female.Checked = true;
            }
            txt_phone.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_address.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            // code xu ly hình anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])guna2DataGridView1.CurrentRow.Cells[6].Value;
            MemoryStream picture = new MemoryStream(pic);
            guna2PictureBox1.Image = Image.FromStream(picture);
            Show();
        }

        private void bt_download_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog(); svf.FileName = ("patient_" + txt_id.Text);
            if ((guna2PictureBox1.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                guna2PictureBox1.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_fullname.Text = "";
            guna2DateTimePicker1.Value = DateTime.Now;
            radiobt_male.Checked = true;
            txt_phone.Text = "";
            txt_address.Text = "";
            guna2PictureBox1.Image = null;
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = txt_fullname.Text;
            DateTime bdate = guna2DateTimePicker1.Value;
            string phone = txt_phone.Text;
            string adrs = txt_address.Text;
            string gender = "Male";

            if (radiobt_female.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = guna2DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            //  sv tu 10-100,  co the thay doi
            if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!IsStringValid(fname) )
            {
                MessageBox.Show("Full name cannot contain numeric characters", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!IsStringValid(fname)  || !IsNumeric(phone) || phone.Length != 10)
            {
                MessageBox.Show("Invalid input. Please check the provided information.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(txt_id.Text);
                    guna2PictureBox1.Image.Save(pic, guna2PictureBox1.Image.RawFormat);
                    if (patients.UpdatePatient(id, fname, adrs, phone, bdate, gender,  pic))
                    {
                        MessageBox.Show("New Patient Edit", "Edit Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Patient", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Patient", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            try
            {
                int patientId = Convert.ToInt32(txt_id.Text);
                // display a confirmation message before the delete
                if ((MessageBox.Show("Are You Sure You Want To Delete This Patient", "Delete Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (patients.DeletePatients(patientId))
                    {
                        MessageBox.Show("Patient Deleted", "Delete Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // clear fields after delete
                        txt_id.Text = "";
                        txt_fullname.Text = "";
                        txt_address.Text = "";
                        txt_phone.Text = "";
                        guna2DateTimePicker1.Value = DateTime.Now;
                        guna2PictureBox1.Image = null;
                    }
                    else
                        MessageBox.Show("Patient Not Deleted", "Delete Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            DataTable table = patients.searchPatients(keyword);
            guna2DataGridView1.DataSource = table;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            DataTable table = patients.searchPatients(keyword);
            guna2DataGridView1.DataSource = table;
        }

        private void bt_refresh_Click(object sender, EventArgs e)
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
    }
}
