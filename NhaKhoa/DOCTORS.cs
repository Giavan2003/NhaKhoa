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
    class DOCTORS
    {
        MYDB mydb = new MYDB();

        public bool InsertDoctor(string fullName, string specialization, DateTime dateOfBirth, string gender, string identityNumber, string address, string email, string phoneNumber, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Doctors (FullName, Specialization, DateOfBirth, Gender, IdentityNumber, Address, Email, PhoneNumber, Image)" +
                " VALUES (@fullName, @specialization, @dateOfBirth, @gender, @identityNumber, @address, @email, @phoneNumber, @image)",
                mydb.getConnection);
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@specialization", SqlDbType.NVarChar).Value = specialization;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@identityNumber", SqlDbType.VarChar).Value = identityNumber;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
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

        public bool UpdateDoctor(int doctorID, string fullName, string specialization, DateTime dateOfBirth, string gender, string identityNumber, string address, string email, string phoneNumber, MemoryStream image)
        {
            SqlCommand command = new SqlCommand("UPDATE Doctors SET FullName = @fullName, Specialization = @specialization, DateOfBirth = @dateOfBirth, Gender = @gender, IdentityNumber = @identityNumber, Address = @address, Email = @email, PhoneNumber = @phoneNumber, Image = @image " +
                "WHERE DoctorID = @doctorID", mydb.getConnection);
            command.Parameters.Add("@doctorID", SqlDbType.Int).Value = doctorID;
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@specialization", SqlDbType.NVarChar).Value = specialization;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@identityNumber", SqlDbType.VarChar).Value = identityNumber;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
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
        

        // Hàm để lấy danh sách bác sĩ
        public DataTable GetDoctors(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getDoctor2()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Doctors", mydb.getConnection);
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        // Hàm để xóa một bác sĩ
        public bool DeleteDoctor(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Doctors WHERE DoctorID = @id", mydb.getConnection);
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
        public string GetNameDoctor(int DoctorID)
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
        // Trong lớp DOCTORS
        // Hàm để tìm kiếm bác sĩ
        public DataTable SearchDoctors(string keyword)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Doctors WHERE FullName LIKE @keyword OR DoctorID LIKE @keyword", mydb.getConnection);
            command.Parameters.Add("@keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public bool IsEmailUnique(string email)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Doctors WHERE Email = @email",
                mydb.getConnection);
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Nếu count > 0, có nghĩa là email đã tồn tại trong cơ sở dữ liệu
            // Ngược lại, email là duy nhất
            return count == 0;
        }

        public bool IsPhoneNumberUnique(string phoneNumber)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Doctors WHERE PhoneNumber = @phoneNumber",
                mydb.getConnection);
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Nếu count > 0, có nghĩa là phoneNumber đã tồn tại trong cơ sở dữ liệu
            // Ngược lại, phoneNumber là duy nhất
            return count == 0;
        }

        public bool IsIdentityNumberUnique(string identityNumber)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Doctors WHERE IdentityNumber = @identityNumber",
                mydb.getConnection);
            command.Parameters.Add("@identityNumber", SqlDbType.VarChar).Value = identityNumber;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Nếu count > 0, có nghĩa là identityNumber đã tồn tại trong cơ sở dữ liệu
            // Ngược lại, identityNumber là duy nhất
            return count == 0;
        }
        public bool IsEmailUnique2(string email, int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Doctors WHERE Email = @email AND DoctorID != @id",
                mydb.getConnection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@id", id);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Nếu count > 0, có nghĩa là email đã tồn tại trong cơ sở dữ liệu
            // Nhưng nếu id trùng khớp, không tính là trùng lặp
            // Ngược lại, email là duy nhất
            return count == 0;
        }

        public bool IsPhoneNumberUnique2(string phoneNumber, int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Doctors WHERE PhoneNumber = @phoneNumber AND DoctorID != @id",
                mydb.getConnection);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@id", id);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Tương tự, kiểm tra số điện thoại
            return count == 0;
        }

        public bool IsIdentityNumberUnique2(string identityNumber, int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Doctors WHERE IdentityNumber = @identityNumber AND DoctorID != @id",
                mydb.getConnection);
            command.Parameters.AddWithValue("@identityNumber", identityNumber);
            command.Parameters.AddWithValue("@id", id);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Tương tự, kiểm tra số CMND
            return count == 0;
        }
    }
}
