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

namespace NhaKhoa.Appointments
{
    public partial class ShowAppointment : Form
    {
        private DateTime selectedDate;
        MYDB mydb = new MYDB();
        public ShowAppointment()
        {
            InitializeComponent();
            selectedDate = DateTime.Today;
            LoadSchedule();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = DateTimePicker1.Value.Date;
            LoadSchedule();
        }
        private void LoadSchedule()
        {
            // Clear existing controls in the panel
            yourPanel.Controls.Clear();

            // Fetch doctors
            DataTable doctorsTable = GetDoctors();
            int numDoctors = doctorsTable.Rows.Count;

            // Calculate the width of the panel based on the number of doctors
            int panelWidth = (numDoctors * 250) + 120; // Adjusted width

            // Set the size of the panel
            yourPanel.Size = new Size(panelWidth, 877);

            // Create labels for time slots
            int timeY = 40; // Start Y position for time labels
            for (int i = 8; i < 18; i++)
            {
                Label timeLabel = new Label();
                timeLabel.Text = i.ToString("00") + ":00";
                timeLabel.Font = new Font("Arial", 14); // Set font size
                timeLabel.AutoSize = true;
                timeLabel.Location = new Point(10, timeY);
                yourPanel.Controls.Add(timeLabel);
                timeY += 40; // Adjust Y position for next time label

                // Add additional label for half-hour intervals
                Label halfHourLabel = new Label();
                halfHourLabel.Text = i.ToString("00") + ":30";
                halfHourLabel.Font = new Font("Arial", 14); // Set font size
                halfHourLabel.AutoSize = true;
                halfHourLabel.Location = new Point(10, timeY);
                yourPanel.Controls.Add(halfHourLabel);
                timeY += 40; // Adjust Y position for next half-hour label
            }

            // Create buttons for each doctor
            int labelX = 130; // Start X position for labels
            foreach (DataRow row in doctorsTable.Rows)
            {
                Label label = new Label();
                label.Text = row["FullName"].ToString();
                label.Font = new Font("Arial", 14, FontStyle.Bold);
                label.AutoSize = true;
                label.Location = new Point(labelX, 10); // Y position can be adjusted
                yourPanel.Controls.Add(label);

                // Fetch appointments for the current doctor
                string doctorName = row["FullName"].ToString();
                DataTable doctorAppointmentsTable = GetDoctorAppointments(selectedDate, doctorName);

                // Create buttons for each appointment
                foreach (DataRow appointmentRow in doctorAppointmentsTable.Rows)
                {
                    DateTime startDateTime = Convert.ToDateTime(appointmentRow["StartDateTime"]);
                    DateTime endDateTime = Convert.ToDateTime(appointmentRow["EndDateTime"]);
                    string description = appointmentRow["Description"].ToString();
                    string status = appointmentRow["Status"].ToString();

                    // Calculate button height based on appointment duration
                    TimeSpan appointmentDuration = endDateTime - startDateTime;
                    int buttonHeight = (int)appointmentDuration.TotalMinutes * 2;

                    // Create button for the appointment
                    Button btn = new Button();
                    btn.Text = description;
                    btn.Tag = startDateTime; // You can store additional data in the Tag property
                    btn.Size = new Size(250, buttonHeight); // Set button size based on appointment duration
                    btn.Location = new Point(labelX, (int)((startDateTime.TimeOfDay.TotalMinutes - 480) / 30) * 40 + 40); // Adjust Y position based on start time
                    btn.FlatStyle = FlatStyle.Flat;

                    // Set button color based on status
                    switch (status)
                    {
                        case "Chưa hoàn thành ":
                            btn.BackColor = Color.Blue;                        
                            break;
                        case "Đã hoàn thành ":
                            btn.BackColor = Color.Green;
                            break;
                        case "Đã bị hủy ":
                            btn.BackColor = Color.Red;
                            break;
                        default:
                            btn.BackColor = Color.Gray;
                            break;
                    }

                    // Add click event handler to show appointment details
                    btn.Click += AppointmentButton_Click;

                    // Add button to your panel
                    yourPanel.Controls.Add(btn);
                }

                // Update labelX for the next doctor
                labelX += 250; // Adjust X position for next label
            }

            // Adjust the size of the scrollable panel
            AdjustScrollablePanelSize(panelWidth);
        }

        private DataTable GetDoctorAppointments(DateTime selectedDate, string doctorName)
        {
            // Fetch appointments for the specified doctor and date from the database
            SqlCommand command = new SqlCommand("SELECT Appointments.StartDateTime, Appointments.EndDateTime, Appointments.Description, Appointments.Status " +
                                "FROM Appointments " +
                                "INNER JOIN Doctors ON Appointments.DoctorID = Doctors.DoctorID " +
                                "WHERE CONVERT(date, Appointments.StartDateTime) = @SelectedDate AND Doctors.FullName = @DoctorName", mydb.getConnection);
            command.Parameters.Add("@SelectedDate", SqlDbType.DateTime).Value = selectedDate;
            command.Parameters.Add("@DoctorName", SqlDbType.NVarChar).Value = doctorName;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable doctorAppointmentsTable = new DataTable();
            adapter.Fill(doctorAppointmentsTable);
            return doctorAppointmentsTable;
        }


        private void AdjustScrollablePanelSize(int panelWidth)
        {
            // Adjust the size of the scrollable panel to accommodate the panel width
            scrollablePanel.Size = new Size(1491, 877);
            scrollablePanel.Controls.Add(yourPanel);

            // Add the ScrollablePanel to the form
            Controls.Add(scrollablePanel);
        }
     


        private void AppointmentButton_Click(object sender, EventArgs e)
        {
            // Handle click event to show appointment details
            Button btn = sender as Button;
            DateTime startDateTime = (DateTime)btn.Tag;
            // Show appointment details in a popup or another panel
            MessageBox.Show("Appointment details: " + btn.Text + " - " + startDateTime.ToString());
        }

        private DataTable GetDoctors()
        {
            // Fetch doctors data from database
            SqlCommand command = new SqlCommand("SELECT FullName FROM Doctors", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable doctorsTable = new DataTable();
            adapter.Fill(doctorsTable);
            return doctorsTable;
        }
    }
}
