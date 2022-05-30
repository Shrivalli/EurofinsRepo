using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ADONETEg
{
    class EmployeeDAL
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public void SelectData()
        {
            con = getcon();
             cmd = new SqlCommand("select * from Employee");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) //number of rows
            {
                for (int i = 0; i < dr.FieldCount; i++) //number of columns
                {
                    Console.Write(dr[i] + " ");
                }
                Console.WriteLine();
            }
        }
    //new method of disconselect
        public void DisconSelect()
        {
            con = getcon();
            cmd = new SqlCommand("select * from Employee;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                foreach(var item in dr.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }
        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=FIS;Integrated Security=true");
            con.Open();
            return con;
        }

        public void InsertData(int eid, string ename, float salary, DateTime doj)
        {
            try
            {
                con = getcon();
                // cmd = new SqlCommand("insert into employee values(@eid,@ename,@sal,@doj)",con);
                cmd = new SqlCommand("spinsertemp", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", eid);
                cmd.Parameters.AddWithValue("@ename", ename);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@doj", doj);
               // cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine(i + " row(s) affected");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
