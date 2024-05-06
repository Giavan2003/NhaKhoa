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
    class EMPLOYESS
    {
        MYDB mydb = new MYDB();
        public bool InsertEmployee(string fullName, DateTime dateOfBirth, string gender, string identityNumber, string address, string email, string phoneNumber, MemoryStream image, int positionID)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Employees (FullName, DateOfBirth, Gender, IdentityNumber, Address, Email, PhoneNumber, Image, PositionID)" +
                " VALUES (@fullName, @dateOfBirth, @gender, @identityNumber, @address, @email, @phoneNumber, @image, @positionID)",
                mydb.getConnection);
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@identityNumber", SqlDbType.NVarChar).Value = identityNumber;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();
            command.Parameters.Add("@positionID", SqlDbType.Int).Value = positionID;

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

        public bool UpdateEmployee(int employeeID, string fullName, DateTime dateOfBirth, string gender, string identityNumber, string address, string email, string phoneNumber, MemoryStream image, int positionID)
        {
            SqlCommand command = new SqlCommand("UPDATE Employees SET FullName = @fullName, DateOfBirth = @dateOfBirth, Gender = @gender, IdentityNumber = @identityNumber, Address = @address, Email = @email, PhoneNumber = @phoneNumber, Image = @image, PositionID = @positionID " +
                "WHERE EmployeeID = @employeeID", mydb.getConnection);
            command.Parameters.Add("@employeeID", SqlDbType.Int).Value = employeeID;
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@identityNumber", SqlDbType.VarChar).Value = identityNumber;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();
            command.Parameters.Add("@positionID", SqlDbType.Int).Value = positionID;

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

        // Hàm để lấy danh sách nhân viên
        public DataTable GetEmployees(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Hàm để xóa một nhân viên
        public bool DeleteEmployee(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @id", mydb.getConnection);
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

        // Trong lớp EMPLOYEES
        // Hàm để tìm kiếm nhân viên
        public DataTable SearchEmployees(string keyword)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE FullName LIKE @keyword OR EmployeeID LIKE @keyword", mydb.getConnection);
            command.Parameters.Add("@keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public bool IsEmailUnique(string email)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE Email = @email",
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
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE PhoneNumber = @phoneNumber",
                mydb.getConnection);
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Nếu count > 0, có nghĩa là số điện thoại đã tồn tại trong cơ sở dữ liệu
            // Ngược lại, số điện thoại là duy nhất
            return count == 0;
        }

        public bool IsIdentityNumberUnique(string identityNumber)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE IdentityNumber = @identityNumber",
                mydb.getConnection);
            command.Parameters.Add("@identityNumber", SqlDbType.VarChar).Value = identityNumber;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Nếu count > 0, có nghĩa là số CMND đã tồn tại trong cơ sở dữ liệu
            // Ngược lại, số CMND là duy nhất
            return count == 0;
        }
        public bool IsEmailUnique2(string email, int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE Email = @email AND EmployeeID != @id",
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
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE PhoneNumber = @phoneNumber AND EmployeeID != @id",
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
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE IdentityNumber = @identityNumber AND EmployeeID != @id",
                mydb.getConnection);
            command.Parameters.AddWithValue("@identityNumber", identityNumber);
            command.Parameters.AddWithValue("@id", id);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            // Tương tự, kiểm tra số CMND
            return count == 0;
        }

        public DataTable ShowEmployees()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT * FROM Employess";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
