using Guna.UI2.WinForms;
using NhaKhoa.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

namespace NhaKhoa
{
    public partial class PatientServiceForm : Form
    {
        public int ServiceId;
        private DataTable serviceData;
        PATIENTS patient = new PATIENTS();
        public PatientServiceForm(int id)
        {
            InitializeComponent();
            ServiceId = id;
        }
        PATIENTMEDICINES patientmed = new PATIENTMEDICINES();
        SERVICES service = new SERVICES();
        STATUS status = new STATUS();
        PLANSERVICES plan = new PLANSERVICES();
        MEDICINES medicines = new MEDICINES();
        DOCTORS doctors = new DOCTORS();
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Thực hiện";
            editButtonColumn.Name = "EditButtonColumn";
            editButtonColumn.Text = "Thực hiện";
            editButtonColumn.UseColumnTextForButtonValue = true;
            guna2DataGridView1.Columns.Add(editButtonColumn);
            DataGridViewButtonColumn editButtonColumn2 = new DataGridViewButtonColumn();
            editButtonColumn2.HeaderText = "Xong";
            editButtonColumn2.Name = "EditButtonColumn";
            editButtonColumn2.Text = "Xong";
            editButtonColumn2.UseColumnTextForButtonValue = true;
            guna2DataGridView2.Columns.Add(editButtonColumn2);
            // Tạo một cột DataGridViewComboBoxColumn
            //DataGridViewComboBoxColumn doctorColumn = new DataGridViewComboBoxColumn();
            doctorColumn.DataPropertyName = "DoctorID"; // Tên cột trong DataTable chứa ID của bác sĩ
            doctorColumn.DisplayMember = "FullName"; // Hiển thị tên của bác sĩ trong combobox
            doctorColumn.ValueMember = "DoctorID"; // Giá trị thực của combobox là ID của bác sĩ
            doctorColumn.DataSource = doctors.getDoctor2(); // Dữ liệu của combobox là danh sách bác sĩ từ bảng Doctors

        }
        private void AddPlanForm_PlanAdded(object sender, EventArgs e)
        {
            LoadData(); // Load lại dữ liệu khi kế hoạch được thêm thành công
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddPlanForm apf = new AddPlanForm(ServiceId);
            apf.PlanAdded += AddPlanForm_PlanAdded;
            apf.Show();
            
        }
        private void LoadData()
        {
            // Hiển thị thông tin của bệnh nhân
            DataTable showpatient = patient.showPatient(ServiceId);
            if (showpatient.Rows.Count > 0)
            {
                DataRow row = showpatient.Rows[0];
                string fullName = row["FullName"].ToString();
                DateTime dateOfBirth = (DateTime)row["DateOfBirth"];
                string address = row["Address"].ToString();
                string phoneNumber = row["PhoneNumber"].ToString();
                string gender = row["Gender"].ToString();

                label1.Text = "Họ tên bệnh nhân: " + fullName;
                label2.Text = "Ngày sinh: " + dateOfBirth.ToString("dd/MM/yyyy");
                label3.Text = "Địa chỉ: " + address;
                label4.Text = "Số điện thoại: " + phoneNumber;
                label5.Text = "Giới tính: " + gender;
            }

            // Hiển thị dữ liệu kế hoạch điều trị
            DataTable dtPlan = plan.ShowPlan(ServiceId);
            guna2DataGridView1.DataSource = dtPlan;

            // Hiển thị dữ liệu kế hoạch hoàn thành
            DataTable dtCompletedPlan = plan.ShowPlan2(ServiceId);
            guna2DataGridView2.DataSource = dtCompletedPlan;

            // Hiển thị danh sách thuốc của bệnh nhân
            DataTable dtMedicines = patientmed.Showmedicines(ServiceId);
            guna2DataGridView3.DataSource = dtMedicines;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView1.Columns["EditButtonColumn"].Index && e.RowIndex >= 0)
            {
                string statusName = guna2DataGridView1.CurrentRow.Cells["StatusName"].Value.ToString();

                if (statusName== "Đã Hoàn Thành")
                {
                    MessageBox.Show("Không thể thực hiện thao tác này do trạng thái đã hoàn thành", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int PlanID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[1].Value.ToString());
                    plan.UpdateStatus1(PlanID, 2);

                    DataTable dt = plan.ShowPlan(ServiceId);
                    guna2DataGridView1.DataSource = dt;

                    DataTable dt2 = plan.ShowPlan2(ServiceId);
                    guna2DataGridView2.DataSource = dt2;
                }
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView2.Columns["EditButtonColumn"].Index && e.RowIndex >= 0)
            {
                string doctorName = guna2DataGridView2.CurrentRow.Cells["DoctorName"].Value.ToString();
                string statusName = guna2DataGridView2.CurrentRow.Cells["StatusName"].Value.ToString();

                if ((doctorName == null && statusName == "Đang Hoàn Thành")|| statusName == "Đã Hoàn Thành")
                {
                    MessageBox.Show("Không thể thực hiện thao tác này do trạng thái là đã được gán cho một bác sĩ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataGridViewRow selectedRow = guna2DataGridView2.Rows[e.RowIndex];
                int PlanID = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());

                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)selectedRow.Cells["doctorColumn"];
                int doctorID = Convert.ToInt32(comboBoxCell.Value);

                plan.UpdateStatus2(PlanID, 3, doctorID);

                DataTable dt2 = plan.ShowPlan2(ServiceId);
                guna2DataGridView2.DataSource = dt2;

                DataTable dt = plan.ShowPlan(ServiceId);
                guna2DataGridView1.DataSource = dt;
            }
        }


        private void bt_themthuoc_Click(object sender, EventArgs e)
        {
            AddMedicinesForm amf = new AddMedicinesForm(ServiceId);
            amf.PlanAdded += AddPlanForm_PlanAdded;
            amf.Show();
        }

        private void bt_thanhtoan_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;
            if (mainForm != null)
            {
                mainForm.container(new PaymentForm(ServiceId));
            }
        }
    }

}
