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
    class EmployeesDAO
    {
        string conStr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;



        public EmployeesDAO()
        {
            conStr = Database.ConnectionString;
        }
        public int CreateEmployee(string empName, String desg, String PhNo, string Email, string Address, string DrLNo,string Username, string Password)
        {
            int empid = 0;
            using (con = new SqlConnection(conStr))
            {
                cmd = new SqlCommand("usp_CreateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;



                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@empid";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;



                cmd.Parameters.Add(p1);



                SqlParameter p2 = new SqlParameter("@empName", empName);
                cmd.Parameters.Add(p2);


                cmd.Parameters.AddWithValue("@desg", desg);
                cmd.Parameters.AddWithValue("@PhNo", PhNo);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@DrLNo", DrLNo);



                con.Open();



                cmd.ExecuteNonQuery();
                empid = Convert.ToInt32(p1.Value);
                return empid;
            }
        }
            public List<Employees> GetAllEmployees()
        {
            List<Employees> empList = new List<Employees>();

            using (con = new SqlConnection(conStr))
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetAllEmployees"; 

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Employees emp = new Employees();

                    emp.EmpId = Convert.ToInt32(dr["EmployeeId"]);
                    emp.EmpName = dr["EmployeeName"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                    emp.PhoneNumber = dr["PhoneNumber"].ToString();
                    emp.EmailId = dr["EmailId"].ToString();
                    emp.EmpAddress = dr["EmpAddress"].ToString();
                    emp.DrivingLicense = dr["DrivingLicense"].ToString();

                    empList.Add(emp);
                }
            }

            return empList;
        }
    }
}
