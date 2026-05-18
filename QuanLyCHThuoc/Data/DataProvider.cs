using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCHThuoc.Data
{
    internal class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
        }
        private DataProvider() { }

        // Sửa tên máy và instance SQL Server của bạn ở đây
        private string sqlConnection =
            "Data Source=DESKTOP-9SJILQ8\\SQLEXPRESS; Initial Catalog=QLCHT; Integrated Security=True";

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
