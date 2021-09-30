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
    class BookingDAO
    {
        string conStr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;



        public BookingDAO()
        {
            conStr = Database.ConnectionString;
        }
        public int CreateBooking(int CustId, int TaxiId, DateTime BookingDt, DateTime TrDate, DateTime StTime, DateTime EndTime, string SrcAddress, string DestAddress)
        {
            int BookingId = 0;
            using (con = new SqlConnection(conStr))
            {
                cmd = new SqlCommand("usp_CreateNewCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;



                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@BookingId";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;



                cmd.Parameters.Add(p1);



                SqlParameter p2 = new SqlParameter("@CustId", CustId);
                cmd.Parameters.Add(p2);



                cmd.Parameters.AddWithValue("@TaxiId", TaxiId);
                cmd.Parameters.AddWithValue("@BookingDt", BookingDt);
                cmd.Parameters.AddWithValue("@TrDate", TrDate);
                cmd.Parameters.AddWithValue("@StTime", StTime);
                cmd.Parameters.AddWithValue("@Endtime", EndTime);
                cmd.Parameters.AddWithValue("@SrcAddress", SrcAddress);
                cmd.Parameters.AddWithValue("@DestAddress", DestAddress);



                con.Open();



                cmd.ExecuteNonQuery();
                BookingId = Convert.ToInt32(p1.Value);
                return BookingId;
            }
        }
    }
}
