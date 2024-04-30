using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa.Appointments
{
    internal class APM
    {
        MYDB mydb = new MYDB();

        // Phương thức để thêm một cuộc hẹn mới
        public bool InsertAppointment(int patientID, int doctorID, DateTime startDateTime, DateTime endDateTime, string description, string status)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Appointments (PatientID, DoctorID, StartDateTime, EndDateTime, Description, Status)" +
                                                " VALUES (@patientID, @doctorID, @startDateTime, @endDateTime, @description, @status)", mydb.getConnection);
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;
            command.Parameters.Add("@doctorID", SqlDbType.Int).Value = doctorID;
            command.Parameters.Add("@startDateTime", SqlDbType.DateTime).Value = startDateTime;
            command.Parameters.Add("@endDateTime", SqlDbType.DateTime).Value = endDateTime;
            command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;

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

        // Phương thức để cập nhật thông tin cuộc hẹn
        public bool UpdateAppointment(int appointmentID, int patientID, int doctorID, DateTime startDateTime, DateTime endDateTime, string description, string status)
        {
            SqlCommand command = new SqlCommand("UPDATE Appointments SET PatientID = @patientID, DoctorID = @doctorID, StartDateTime = @startDateTime, EndDateTime = @endDateTime, " +
                                                "Description = @description, Status = @status WHERE AppointmentID = @appointmentID", mydb.getConnection);
            command.Parameters.Add("@appointmentID", SqlDbType.Int).Value = appointmentID;
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;
            command.Parameters.Add("@doctorID", SqlDbType.Int).Value = doctorID;
            command.Parameters.Add("@startDateTime", SqlDbType.DateTime).Value = startDateTime;
            command.Parameters.Add("@endDateTime", SqlDbType.DateTime).Value = endDateTime;
            command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;

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

        // Phương thức để lấy danh sách các cuộc hẹn
        public DataTable GetAppointments(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Phương thức để xóa một cuộc hẹn
        public bool DeleteAppointment(int appointmentID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Appointments WHERE AppointmentID = @appointmentID", mydb.getConnection);
            command.Parameters.Add("@appointmentID", SqlDbType.Int).Value = appointmentID;

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
        public bool IsAppointmentOverlapping(int doctorID, DateTime startDateTime, DateTime endDateTime)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Appointments " +
                                                "WHERE DoctorID = @doctorID AND " +
                                                "      CONVERT(date, StartDateTime) = CONVERT(date, @startDateTime) AND " +
                                                "      @startDateTime < EndDateTime AND @endDateTime > StartDateTime", mydb.getConnection);
            command.Parameters.Add("@doctorID", SqlDbType.Int).Value = doctorID;
            command.Parameters.Add("@startDateTime", SqlDbType.DateTime).Value = startDateTime;
            command.Parameters.Add("@endDateTime", SqlDbType.DateTime).Value = endDateTime;

            mydb.openConnection();

            int count = Convert.ToInt32(command.ExecuteScalar());

            mydb.closeConnection();

            return count > 0;
        }



        // Phương thức để tìm kiếm cuộc hẹn
        public DataTable SearchAppointments(string keyword)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Appointments WHERE AppointmentID LIKE @keyword OR PatientID LIKE @keyword OR DoctorID LIKE @keyword OR Description LIKE @keyword OR Status LIKE @keyword", mydb.getConnection);
            command.Parameters.Add("@keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
