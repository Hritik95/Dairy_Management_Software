using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyManagementSoftware
{
    internal class record_class
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-39R8HFFR\SQLEXPRESS;Initial Catalog=dairymanagement;Integrated Security=True");
        SqlCommand cmd;

        SqlCommandBuilder bld;
        SqlDataAdapter adpt;


        public int addData(int id, String date, String milk_type, String session, int total_milk, int fat, int snf, int tot_amt)
        {
            try
            {
                con.Open();
                String query = "insert into milk_collection_details values(" + id + ",'" + date + "','" + milk_type + "','" + session + "','" + total_milk + "','"+ fat + "','"+ snf +"', '"+ tot_amt +"')";
                cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();
                con.Close();
                return no;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public DataTable display(int id)
        {
            String qry;
            con.Open();

            if (id == 0)
            {
                qry = "select * from milk_collection_details";
            }
            else
            {
                qry = "select * from milk_collection_details where Member_id = '" + id + "'";
            }

            adpt = new SqlDataAdapter(qry, con);
            bld = new SqlCommandBuilder(adpt);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public String sum_coll(int id, String Date1, String Date2)
        {
            String str;
            con.Open();
            String qry = "Select sum(Total_Amount) as sum from milk_collection_details where Member_id = '"+id+"' and Date between '"+Date1+"' and '"+Date2+"'";
            cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                str = dr["sum"].ToString();
            }
            else
            {
                str = "error";
            }
            return str;
        }
    }
}
