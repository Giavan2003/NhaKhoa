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
    public partial class EmployeesMangementForm : Form
    {
        public EmployeesMangementForm()
        {
            InitializeComponent();
        }

        EMPLOYESS employess = new EMPLOYESS();
        private void bt_add_Click(object sender, EventArgs e)
        {
            string fname = txt_fullname.Text;
            int position = (int)guna2ComboBox1.SelectedValue;
            string identitynumber = txt_identitynumber.Text;
            string email = txt_email.Text;
            DateTime bdate = guna2DateTimePicker1.Value;
            string phone = txt_phonenumber.Text;
            string adrs = txt_address.Text;
            string gender = "Male";

            if (radiobt_female.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = guna2DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            // Kiểm tra tuổi hợp lệ của sinh viên
            if (((this_year - born_year) < 18) || ((this_year - born_year) > 60))
            {
                MessageBox.Show("The Employee Age Must Be Between 18 and 60 years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsStringValid(fname))
            {
                MessageBox.Show("Full name cannot contain numeric characters", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!IsStringValid(fname) || !IsNumeric(phone) || phone.Length != 10)
            {
                MessageBox.Show("Invalid input. Please check the provided information.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!employess.IsEmailUnique(email))
            {
                MessageBox.Show("Email already exists. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!employess.IsPhoneNumberUnique(phone))
            {
                MessageBox.Show("Phone number already exists. Please use a different phone number.", "Duplicate Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!employess.IsIdentityNumberUnique(identitynumber))
            {
                MessageBox.Show("Identity number already exists. Please use a different identity number.", "Duplicate Identity Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (verif())
            {
                guna2PictureBox1.Image.Save(pic, guna2PictureBox1.Image.RawFormat);
                if (!employess.InsertEmployee(fname, bdate, gender, identitynumber, adrs, email, phone, pic, position))
                {
                    MessageBox.Show("New Employee Added", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
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
                        || (txt_phonenumber.Text.Trim() == "")
                        || (guna2PictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EmployeesMangementForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dENTALDataSet2.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.dENTALDataSet2.Employees);
            SqlCommand command = new SqlCommand("SELECT * FROM Employees");
            //SqlCommand command = new SqlCommand("SELECT DISTINCT std.Id, std.fname, std.lname, std.bdate, std.gender, std.phone, std.email, std.address, std.picture, course.lable \r\nFROM std \r\nLEFT JOIN subject ON std.Id = subject.StudentId \r\nLEFT JOIN course ON subject.CourseId = course.Id;\r\n");
            guna2DataGridView1.ReadOnly = true;
            // xu ly hình anh, code co tham khao msdn
            DataGridViewImageColumn piccol = new DataGridViewImageColumn(); // doi tuong lam viec voi dang picture cua datagridview
            guna2DataGridView1.RowTemplate.Height = 80; // dong nay tham khao tren MSDN ngay 10/03/2019,co gian de pic dep, dang tim auto-size
            guna2DataGridView1.DataSource = employess.GetEmployees(command);
            imageDataGridViewImageColumn = (DataGridViewImageColumn)guna2DataGridView1.Columns[8];
            imageDataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            guna2DataGridView1.AllowUserToAddRows = false;
            POSITION position = new POSITION();
            guna2ComboBox1.DataSource = position.getPosition();
            guna2ComboBox1.DisplayMember = "Name";
            guna2ComboBox1.ValueMember = "PositionID";
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = txt_fullname.Text;
            int position = (int)guna2ComboBox1.SelectedValue;
            string identitynumber = txt_identitynumber.Text;
            string email = txt_email.Text;
            DateTime bdate = guna2DateTimePicker1.Value;
            string phone = txt_phonenumber.Text;
            string adrs = txt_address.Text;
            string gender = "Male";

            if (radiobt_female.Checked)
            {
                gender = "Female";
            }
            id = Convert.ToInt32(txt_id.Text);
            MemoryStream pic = new MemoryStream();
            int born_year = guna2DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 18) || ((this_year - born_year) > 60))
            {
                MessageBox.Show("The Employee Age Must Be Between 18 and 60 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!IsStringValid(fname))
            {
                MessageBox.Show("Full name cannot contain numeric characters", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!IsStringValid(fname) || !IsNumeric(phone) || phone.Length != 10)
            {
                MessageBox.Show("Invalid input. Please check the provided information.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!employess.IsEmailUnique2(email, id))
            {
                MessageBox.Show("Email already exists. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!employess.IsPhoneNumberUnique2(phone, id))
            {
                MessageBox.Show("Phone number already exists. Please use a different phone number.", "Duplicate Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!employess.IsIdentityNumberUnique2(identitynumber, id))
            {
                MessageBox.Show("Identity number already exists. Please use a different identity number.", "Duplicate Identity Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (verif())
            {
                try
                {
                    guna2PictureBox1.Image.Save(pic, guna2PictureBox1.Image.RawFormat);
                    if (employess.UpdateEmployee(id, fname, bdate, gender, identitynumber, adrs, email, phone, pic, position))
                    {
                        MessageBox.Show("New Employee Edit", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            try
            {
                int employessid = Convert.ToInt32(txt_id.Text);
                // display a confirmation message before the delete
                if ((MessageBox.Show("Are You Sure You Want To Delete This Employee", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (employess.DeleteEmployee(employessid))
                    {
                        MessageBox.Show("Employee Deleted", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // clear fields after delete
                        txt_id.Text = "";
                        txt_fullname.Text = "";
                        txt_address.Text = "";
                        txt_phonenumber.Text = "";
                        txt_identitynumber.Text = "";
                        guna2ComboBox1 = null;
                        guna2DateTimePicker1.Value = DateTime.Now;
                        guna2PictureBox1.Image = null;
                    }
                    else
                        MessageBox.Show("Employee Not Deleted", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_fullname.Text = "";
            txt_email.Text = "";
            txt_identitynumber.Text = "";
            POSITION position = new POSITION();
            guna2ComboBox1.DataSource = position.getPosition();
            guna2ComboBox1.DisplayMember = "Name";
            guna2ComboBox1.ValueMember = "PositionID";
            guna2DateTimePicker1.Value = DateTime.Now;
            radiobt_male.Checked = true;
            txt_phonenumber.Text = "";
            txt_address.Text = "";
            guna2PictureBox1.Image = null;
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            this.employeesTableAdapter.Fill(this.dENTALDataSet2.Employees);
            SqlCommand command = new SqlCommand("SELECT * FROM Employees");
            //SqlCommand command = new SqlCommand("SELECT DISTINCT std.Id, std.fname, std.lname, std.bdate, std.gender, std.phone, std.email, std.address, std.picture, course.lable \r\nFROM std \r\nLEFT JOIN subject ON std.Id = subject.StudentId \r\nLEFT JOIN course ON subject.CourseId = course.Id;\r\n");
            guna2DataGridView1.ReadOnly = true;
            // xu ly hình anh, code co tham khao msdn
            DataGridViewImageColumn piccol = new DataGridViewImageColumn(); // doi tuong lam viec voi dang picture cua datagridview
            guna2DataGridView1.RowTemplate.Height = 80; // dong nay tham khao tren MSDN ngay 10/03/2019,co gian de pic dep, dang tim auto-size
            guna2DataGridView1.DataSource = employess.GetEmployees(command);
            imageDataGridViewImageColumn = (DataGridViewImageColumn)guna2DataGridView1.Columns[8];
            imageDataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            guna2DataGridView1.AllowUserToAddRows = false;
        }

        private void bt_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                guna2PictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void bt_download_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog(); svf.FileName = ("employess_" + txt_id.Text);
            if ((guna2PictureBox1.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                guna2PictureBox1.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // thu tu cua cac cot: id fname Inane bdgdr phn adrs - pic
            txt_id.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fullname.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_identitynumber.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();

            // Lấy PositionID từ cột tương ứng trong DataGridView
            int positionID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[9].Value);

            // Tạo một đối tượng POSITION để truy vấn và lấy tên vị trí từ PositionID
            POSITION position = new POSITION();

            // Lấy tên vị trí dựa trên PositionID
            string positionName = position.getPositionNameById(positionID);

            // Thiết lập giá trị của combobox thành tên vị trí
            guna2ComboBox1.Text = positionName;


            txt_email.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            guna2DateTimePicker1.Value = (DateTime)guna2DataGridView1.CurrentRow.Cells[2].Value;
            // gender
            if ((guna2DataGridView1.CurrentRow.Cells[3].Value.ToString().Trim() == "Male"))
            {
                radiobt_male.Checked = true;
            }
            else
            {
                radiobt_female.Checked = true;
            }
            txt_phonenumber.Text = guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_address.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            // code xu ly hình anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])guna2DataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            guna2PictureBox1.Image = Image.FromStream(picture);
            Show();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // thu tu cua cac cot: id fname Inane bdgdr phn adrs - pic
            txt_id.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fullname.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_identitynumber.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();

            // Lấy PositionID từ cột tương ứng trong DataGridView
            int positionID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[9].Value);

            // Tạo một đối tượng POSITION để truy vấn và lấy tên vị trí từ PositionID
            POSITION position = new POSITION();

            // Lấy tên vị trí dựa trên PositionID
            string positionName = position.getPositionNameById(positionID);

            // Thiết lập giá trị của combobox thành tên vị trí
            guna2ComboBox1.Text = positionName;


            txt_email.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            guna2DateTimePicker1.Value = (DateTime)guna2DataGridView1.CurrentRow.Cells[2].Value;
            // gender
            if ((guna2DataGridView1.CurrentRow.Cells[3].Value.ToString().Trim() == "Male"))
            {
                radiobt_male.Checked = true;
            }
            else
            {
                radiobt_female.Checked = true;
            }
            txt_phonenumber.Text = guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_address.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            // code xu ly hình anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])guna2DataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            guna2PictureBox1.Image = Image.FromStream(picture);
            Show();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            DataTable table = employess.SearchEmployees(keyword);
            guna2DataGridView1.DataSource = table;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            DataTable table = employess.SearchEmployees(keyword);
            guna2DataGridView1.DataSource = table;
        }
    }
}
