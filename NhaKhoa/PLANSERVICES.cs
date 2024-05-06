using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NhaKhoa
{
    class PLANSERVICES
    {
        MYDB mydb = new MYDB();
        public DataTable ShowPlan(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT PlanID, Services.Name AS ServiceName,Quantity,TreatmentPlans.Price AS Price, PlanDate AS PlanDate, Discount, Payment, Status.Name AS StatusName " +
                                  "FROM TreatmentPlans " +
                                  "INNER JOIN Services ON TreatmentPlans.ServiceID = Services.ServiceID " +
                                  "INNER JOIN Patients ON TreatmentPlans.PatientID = Patients.PatientID " +
                                  "INNER JOIN Status ON TreatmentPlans.StatusID = Status.Id " +
                                  "WHERE TreatmentPlans.PatientID = @PatientID";

            // Thêm tham số cho câu lệnh
            command.Parameters.AddWithValue("@PatientID", patientID);

            // Tạo một đối tượng SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Tạo một đối tượng DataTable
            DataTable table = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            adapter.Fill(table);

            // Trả về DataTable đã tạo
            return table;
        }
        public DataTable ShowPlan2(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT PlanID,Doctors.FullName AS DoctorName, Services.Name AS ServiceName, Quantity, PlanDate AS PlanDate, TreatmentPlans.Price, Status.Name AS StatusName " +
                                  "FROM TreatmentPlans " +
                                  "INNER JOIN Services ON TreatmentPlans.ServiceID = Services.ServiceID " +
                                  "INNER JOIN Patients ON TreatmentPlans.PatientID = Patients.PatientID " +
                                  "INNER JOIN Status ON TreatmentPlans.StatusID = Status.Id " +
                                  "LEFT  JOIN Doctors ON TreatmentPlans.DoctorID = Doctors.DoctorID " +
                                  "WHERE TreatmentPlans.PatientID = @PatientID and TreatmentPlans.StatusID != 1 ";

            // Thêm tham số cho câu lệnh
            command.Parameters.AddWithValue("@PatientID", patientID);

            // Tạo một đối tượng SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Tạo một đối tượng DataTable
            DataTable table = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            adapter.Fill(table);

            // Trả về DataTable đã tạo
            return table;
        }
        public DataTable ShowPlan3(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT DISTINCT Doctors.FullName AS DoctorName, Doctors.DoctorID AS DoctorID " +
                                  "FROM TreatmentPlans " +
                                  "INNER JOIN Services ON TreatmentPlans.ServiceID = Services.ServiceID " +
                                  "INNER JOIN Patients ON TreatmentPlans.PatientID = Patients.PatientID " +
                                  "INNER JOIN Status ON TreatmentPlans.StatusID = Status.Id " +
                                  "INNER JOIN Doctors ON TreatmentPlans.DoctorID = Doctors.DoctorID " +
                                  "WHERE TreatmentPlans.PatientID = @PatientID AND TreatmentPlans.StatusID != 1";

            // Thêm tham số cho câu lệnh
            command.Parameters.AddWithValue("@PatientID", patientID);

            // Tạo một đối tượng SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Tạo một đối tượng DataTable
            DataTable table = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            adapter.Fill(table);

            // Trả về DataTable đã tạo
            return table;
        }
        public bool InsertTreatmentPlan(int serviceID, int patientID, int quantity, DateTime planDate, int statusID, double price, int? doctorID, double discount, double payment, int paid)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO TreatmentPlans (ServiceID, PatientID, Quantity, PlanDate, StatusID, Price, DoctorID, Discount, Payment, Paid)" +
                " VALUES (@serviceID, @patientID, @quantity, @planDate, @statusID, @price, @doctorID, @discount, @payment, @paid)", mydb.getConnection))
            {
                command.Parameters.Add("@serviceID", SqlDbType.Int).Value = serviceID;
                command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@planDate", SqlDbType.Date).Value = planDate;
                command.Parameters.Add("@statusID", SqlDbType.Int).Value = statusID;
                command.Parameters.Add("@price", SqlDbType.Float).Value = price;
                command.Parameters.Add("@doctorID", SqlDbType.Int).Value = (object)doctorID ?? DBNull.Value;
                command.Parameters.Add("@discount", SqlDbType.Float).Value = discount;
                command.Parameters.Add("@payment", SqlDbType.Float).Value = payment;
                command.Parameters.Add("@paid", SqlDbType.Int).Value = paid;

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
        }

        public bool UpdateTreatmentPlan(int planID, int serviceID, int quantity, int patientID, DateTime planDate, int statusID, double price, int? doctorID, int discount, double payment)
        {
            using (SqlCommand command = new SqlCommand("UPDATE TreatmentPlans SET ServiceID = @serviceID, PatientID = @patientID, Quantity = @quantity, PlanDate = @planDate, StatusID = @statusID, Price = @price, DoctorID = @doctorID, Discount = @discount, Payment = @payment WHERE PlanID = @planID", mydb.getConnection))
            {
                command.Parameters.Add("@serviceID", SqlDbType.Int).Value = serviceID;
                command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@planDate", SqlDbType.Date).Value = planDate;
                command.Parameters.Add("@statusID", SqlDbType.Int).Value = statusID;
                command.Parameters.Add("@price", SqlDbType.Float).Value = price;
                command.Parameters.Add("@doctorID", SqlDbType.Int).Value = (object)doctorID ?? DBNull.Value;
                command.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                command.Parameters.Add("@payment", SqlDbType.Float).Value = payment;
                command.Parameters.Add("@planID", SqlDbType.Int).Value = planID;

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
        }

        public bool UpdateStatus1(int PlanID, int newStatusID)
        {
            SqlCommand command = new SqlCommand("UPDATE TreatmentPlans SET StatusID = @newStatusID WHERE PlanID = @PlanID", mydb.getConnection);
            command.Parameters.Add("@newStatusID", SqlDbType.Int).Value = newStatusID;
            command.Parameters.Add("@PlanID", SqlDbType.Int).Value = PlanID;

            mydb.openConnection();

            if (command.ExecuteNonQuery() > 0)
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
        public bool UpdateStatus2(int PlanID, int newStatusID, int doctorId)
        {
            SqlCommand command = new SqlCommand("UPDATE TreatmentPlans SET StatusID = @newStatusID, DoctorID = @doctorID WHERE PlanID = @PlanID", mydb.getConnection);
            command.Parameters.Add("@newStatusID", SqlDbType.Int).Value = newStatusID;
            command.Parameters.Add("@doctorID", SqlDbType.Int).Value = doctorId;
            command.Parameters.Add("@PlanID", SqlDbType.Int).Value = PlanID;

            mydb.openConnection();

            if (command.ExecuteNonQuery() > 0)
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
        public string getDoctorNameById(int DoctorID)
        {
            string DoctorName = "";
            using (SqlConnection connection = new SqlConnection(mydb.getConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT FullName FROM Doctors WHERE DoctorID = @DoctorID", connection))
                {
                    command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        DoctorName = reader["FullName"].ToString();
                    }
                }
            }
            return DoctorName;
        }
        public DataTable Showpay(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT Services.Name, TreatmentPlans.Price, TreatmentPlans.Quantity, TreatmentPlans.Discount, TreatmentPlans.Payment " +
                                    "FROM TreatmentPlans " +
                                    "INNER JOIN Services ON TreatmentPlans.ServiceID = Services.ServiceID " +
                                    "WHERE TreatmentPlans.PatientID = @PatientsID AND TreatmentPlans.Paid = 0;";

            // Thêm tham số cho câu lệnh
            command.Parameters.AddWithValue("@PatientsID", patientID);

            // Tạo một đối tượng SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Tạo một đối tượng DataTable
            DataTable table = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            adapter.Fill(table);

            // Trả về DataTable đã tạo
            return table;
        }
        public bool UpdatePaid(int patientID)
        {
            using (SqlCommand command = new SqlCommand("UPDATE TreatmentPlans SET Paid = 1 WHERE PatientID = @patientID AND Paid = 0", mydb.getConnection))
            {
                command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;

                mydb.openConnection();

                int rowsAffected = command.ExecuteNonQuery();

                mydb.closeConnection();

                return rowsAffected > 0;
            }
        }

    }
}
