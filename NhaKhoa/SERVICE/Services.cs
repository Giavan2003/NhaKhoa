using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa.SERVICE
{
    internal class Services
    {
        MYDB mydb = new MYDB();

        // Hàm để lấy danh sách tất cả các dịch vụ
        public DataTable GetAllServices()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Services", mydb.getConnection);
            return GetServices(command);
        }

        // Hàm để chèn một dịch vụ mới
        public bool InsertService(string name, string unit, float price, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Services (Name, Unit, Price, Description) VALUES (@name, @unit, @price, @description)", mydb.getConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@unit", unit);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@description", description);

            return ExecuteNonQuery(command);
        }
        public DataTable SearchServices(string keyword)
        {
            // Mở kết nối đến cơ sở dữ liệu
            SqlConnection connection = mydb.getConnection;
            connection.Open();

            // Chuỗi truy vấn SQL để tìm kiếm thuốc dựa trên tên hoặc mô tả
            string query = "SELECT * FROM Services  WHERE Name LIKE @keyword OR Description LIKE @keyword";

            // Tạo đối tượng SqlCommand để thực hiện truy vấn
            SqlCommand command = new SqlCommand(query, connection);

            // Thay thế tham số @keyword trong truy vấn với giá trị thực của keyword
            command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Tạo đối tượng DataTable để chứa dữ liệu từ cơ sở dữ liệu
            DataTable table = new DataTable();

            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            adapter.Fill(table);

            // Đóng kết nối cơ sở dữ liệu
            connection.Close();

            // Trả về DataTable chứa kết quả tìm kiếm
            return table;
        }
        // Hàm để cập nhật thông tin một dịch vụ
        public bool UpdateService(int serviceID, string name, string unit, float price, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE Services SET Name = @name, Unit = @unit, Price = @price, Description = @description WHERE ServiceID = @serviceID", mydb.getConnection);
            command.Parameters.AddWithValue("@serviceID", serviceID);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@unit", unit);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@description", description);

            return ExecuteNonQuery(command);
        }

        // Hàm để xóa một dịch vụ
        public bool DeleteService(int serviceID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Services WHERE ServiceID = @serviceID", mydb.getConnection);
            command.Parameters.AddWithValue("@serviceID", serviceID);

            return ExecuteNonQuery(command);
        }

        // Hàm để lấy dữ liệu từ câu truy vấn và trả về DataTable
        private DataTable GetServices(SqlCommand command)
        {
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(table);
            }
            return table;
        }

        // Hàm để thực thi một truy vấn không trả về kết quả (INSERT, UPDATE, DELETE)
        private bool ExecuteNonQuery(SqlCommand command)
        {
            mydb.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            mydb.closeConnection();
            return rowsAffected > 0;
        }
    }
}
