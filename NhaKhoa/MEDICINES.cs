using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa
{
    class MEDICINES
    {
        MYDB mydb = new MYDB();
        public DataTable getMedicines()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Medicines", mydb.getConnection);
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool InsertPatientsMedicines(int patientID, int medicineID, int quantity, int doctorID, double payment, double discount, double price, int paid)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO PatientsMedicines (PatientsID, MedicineID, Quantity, DoctorID, Payment, Discount, Price ,Paid)" +
                " VALUES (@patientID, @medicineID, @quantity, @doctorID, @payment, @discount, @price, @paid)", mydb.getConnection))
            {
                command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;
                command.Parameters.Add("@medicineID", SqlDbType.Int).Value = medicineID;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@doctorID", SqlDbType.Int).Value = doctorID;
                command.Parameters.Add("@payment", SqlDbType.Float).Value = payment;
                command.Parameters.Add("@discount", SqlDbType.Float).Value = discount;
                command.Parameters.Add("@price", SqlDbType.Float).Value = price;
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
        public DataTable GetPatientsMedicinesInfo(int patientID)
        {

            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = @"SELECT M.Name AS MedicineName,PM.Price,PM.Quantity,PM.Discount,PM.Payment" +
                             "FROM PatientsMedicines PM" +
                             "INNER JOIN Medicines M ON PM.MedicineID = M.MedicineID" +
                             "WHERE PM.PatientsID = @patientID";

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
        public DataTable Showpay(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT Medicines.Name, PatientsMedicines.Price, PatientsMedicines.Quantity, PatientsMedicines.Discount, PatientsMedicines.Payment " +
                                    "FROM PatientsMedicines " +
                                    "INNER JOIN Medicines ON PatientsMedicines.MedicineID = Medicines.MedicineID " +
                                    "WHERE PatientsMedicines.PatientsID = @PatientsID AND PatientsMedicines.Paid = 0;";

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
            using (SqlCommand command = new SqlCommand("UPDATE PatientsMedicines SET Paid = 1 WHERE PatientsID = @patientID AND Paid = 0", mydb.getConnection))
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
