using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessEntities;

namespace DataAccessLayer
{
   public class TaxiDAO
    {
        string conStr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;

 

        public TaxiDAO()
        {
            conStr = Database.ConnectionString;
        }
        public int CreateTaxi(string TaxiModel, String Color, string RegistrationNumber, string TaxiType)
        {
            int id = 0;
            using (con = new SqlConnection(conStr))
            {
                cmd = new SqlCommand("usp_CreateTaxi", con);
                cmd.CommandType = CommandType.StoredProcedure;

 

                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@TaxiId";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;

 

                cmd.Parameters.Add(p1);

 

                SqlParameter p2 = new SqlParameter("@TaxiModel", TaxiModel);
                cmd.Parameters.Add(p2);

 

                cmd.Parameters.AddWithValue("@color", Color);
                cmd.Parameters.AddWithValue("@RegNo", RegistrationNumber);
                cmd.Parameters.AddWithValue("@Taxitype", TaxiType);
                
                con.Open();

 

                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(p1.Value);
                return id;
            }
        }
    }
}
