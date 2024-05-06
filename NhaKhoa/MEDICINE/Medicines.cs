using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa.MEDICINE
{
    internal class Medicines
    {
        MYDB mydb = new MYDB();

        // Hàm để lấy danh sách các thuốc
        public DataTable GetAllMedicines()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Medicines", mydb.getConnection);
            return GetMedicines(command);
        }

        // Hàm để chèn một thuốc mới
        public bool InsertMedicine(string name, string unit, string description, float price)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Medicines (Name, Unit, Description, Price) VALUES (@name, @unit, @description, @price)", mydb.getConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@unit", unit);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@price", price);

            return ExecuteNonQuery(command);
        }
      

        // Hàm để cập nhật thông tin một thuốc
        public bool UpdateMedicine(int medicineID, string name, string unit, string description, float price)
        {
            SqlCommand command = new SqlCommand("UPDATE Medicines SET Name = @name, Unit = @unit, Description = @description, Price = @price WHERE MedicineID = @medicineID", mydb.getConnection);
            command.Parameters.AddWithValue("@medicineID", medicineID);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@unit", unit);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@price", price);

            return ExecuteNonQuery(command);
        }

        public DataTable SearchMedicines(string keyword)
        {
            // Mở kết nối đến cơ sở dữ liệu
            SqlConnection connection = mydb.getConnection;
            connection.Open();

            // Chuỗi truy vấn SQL để tìm kiếm thuốc dựa trên tên hoặc mô tả
            string query = "SELECT * FROM Medicines WHERE Name LIKE @keyword OR Description LIKE @keyword";

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

        // Hàm để xóa một thuốc
        public bool DeleteMedicine(int medicineID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Medicines WHERE MedicineID = @medicineID", mydb.getConnection);
            command.Parameters.AddWithValue("@medicineID", medicineID);

            return ExecuteNonQuery(command);
        }

        // Hàm để lấy dữ liệu từ câu truy vấn và trả về DataTable
        private DataTable GetMedicines(SqlCommand command)
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
