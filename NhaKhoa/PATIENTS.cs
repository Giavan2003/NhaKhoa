using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa
{
    class PATIENTS
    {
        MYDB mydb = new MYDB();


        //  function to insert a new student
        public bool InsertPatient(string fullName, string address, string phoneNumber, DateTime dateOfBirth, string gender, byte[] image)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Patients (FullName, Address, PhoneNumber, DateOfBirth, Gender, Image)" +
                " VALUES (@fullName, @address, @phoneNumber, @dateOfBirth, @gender, @image)", mydb.getConnection);
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image;//.ToArray();

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
        public bool UpdatePatient(int patientID, string fullName, string address, string phoneNumber, DateTime dateOfBirth, string gender, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("UPDATE Patients SET FullName = @fullName, Address = @address, PhoneNumber = @phoneNumber, DateOfBirth = @dateOfBirth, Gender = @gender, Image = @image WHERE PatientID = @patientID", mydb.getConnection);
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientID;
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();

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
        public DataTable getPatients(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool DeletePatients(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Patients WHERE PatientID = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
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
        public DataTable showPatient(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT * FROM Patients WHERE PatientID = @PatientsID";

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
        // Trong lớp PATIENTS
        public DataTable searchPatients(string keyword)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Patients WHERE FullName LIKE @keyword OR PatientID LIKE @keyword", mydb.getConnection);
            command.Parameters.Add("@keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

    }
}
