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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            MYDB db = new MYDB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();


            SqlCommand command = new SqlCommand("SELECT * FROM Account WHERE UserName = @User AND Password = @Pass ", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = txt_username.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txt_password.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            
            if ((table.Rows.Count > 0) && radiobt_staff.Checked)
            {
                int role = Convert.ToInt16(table.Rows[0][3].ToString());
                if(role == 3)
                {   //this.DialogResult = DialogResult.OK;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if ((table.Rows.Count > 0) && radiobt_admin.Checked )
            {
                int role = Convert.ToInt16(table.Rows[0][3].ToString());
                if (role == 1)
                {   //this.DialogResult = DialogResult.OK;
                    AdminMainForm mainForm = new AdminMainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if ((table.Rows.Count > 0) && radiobt_dentist.Checked )
            {
                int role = Convert.ToInt16(table.Rows[0][3].ToString());
                if (role == 2)
                {   //this.DialogResult = DialogResult.OK;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
