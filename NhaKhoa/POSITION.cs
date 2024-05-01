using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa
{
    class POSITION
    {
        MYDB mydb = new MYDB();
        public DataTable getPosition()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Position", mydb.getConnection);
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string getPositionNameById(int positionID)
        {
            string positionName = "";
            using (SqlConnection connection = new SqlConnection(mydb.getConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Name FROM Position WHERE PositionID = @PositionID", connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        positionName = reader["Name"].ToString();
                    }
                }
            }
            return positionName;
        }

    }
}
