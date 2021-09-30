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

    class CustomerDAO
    {
        string conStr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;



        public CustomerDAO()
        {
            conStr = Database.ConnectionString;
        }
        public int CreateCustomer(string CustName, String PhNo, string Email, string Address, string Username, string Password)
        {
            int Custid = 0;
            using (con = new SqlConnection(conStr))
            {
                cmd = new SqlCommand("usp_CreateNewCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;



                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@CustId";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;



                cmd.Parameters.Add(p1);



                SqlParameter p2 = new SqlParameter("@CustName", CustName);
                cmd.Parameters.Add(p2);



                cmd.Parameters.AddWithValue("@PhNo", PhNo);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);



                con.Open();



                cmd.ExecuteNonQuery();
                Custid = Convert.ToInt32(p1.Value);
                return Custid;
            }
        }
    }
}
