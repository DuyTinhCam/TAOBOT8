using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAOBOT8
{
    public class ketnoivoianh
    {
        static string strCon = @"Data Source=DESKTOP-38UPOVL\SQLEXPRESS;Initial Catalog=SQL_QLBH;Integrated Security=True";
        public static string Tim_mh(string tenMH)
        {
            string kq = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(strCon))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "Tim_mh";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@tenMH", SqlDbType.NVarChar, 50).Value = tenMH;
                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq = (string)obj;
                        else
                            kq = $"không có MH nào tên: {tenMH}";
                    }
                }
            }
            catch (Exception ex)
            {
                kq += $"Error: {ex.Message}";
            }
            return kq;
        }
    }

}
