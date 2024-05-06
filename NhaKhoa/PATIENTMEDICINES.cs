using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa
{
    class PATIENTMEDICINES
    {
        MYDB mydb = new MYDB();
        public DataTable Showmedicines(int patientID)
        {
            // Tạo một đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // Thiết lập kết nối của SqlCommand
            command.Connection = mydb.getConnection;

            // Sử dụng tham số trong câu lệnh để tránh tình trạng SQL injection
            command.CommandText = "SELECT Medicines.Name, PatientsMedicines.Price, PatientsMedicines.Quantity, PatientsMedicines.Discount, PatientsMedicines.Payment " +
                                 "FROM PatientsMedicines " +
                                 "INNER JOIN Medicines ON PatientsMedicines.MedicineID = Medicines.MedicineID " +
                                 "WHERE PatientsMedicines.PatientsID = @PatientsID AND PatientsMedicines.Paid = 0";



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
    }
}
