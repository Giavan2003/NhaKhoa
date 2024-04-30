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

    }
}
