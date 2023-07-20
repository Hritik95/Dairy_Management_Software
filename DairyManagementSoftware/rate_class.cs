using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace DairyManagementSoftware
{
    internal class rate_class
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-39R8HFFR\SQLEXPRESS;Initial Catalog=dairymanagement;Integrated Security=True");
        SqlCommand cmd;

        SqlCommandBuilder bld;
        SqlDataAdapter adpt;

        public Tuple<String, String, String> Fetch_data_fat(int id)
        {
            con.Open();
            String query = "Select start_fat,end_fat,increment from cow_fat where id = '" + id + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String a = reader["start_fat"].ToString();
                String b = reader["end_fat"].ToString();
                String c = reader["increment"].ToString();
                con.Close();
                return new Tuple<String, String, String>(a, b, c);
            }
            else
            {
                con.Close();
                return new Tuple<String, String, String>("a", "b", "-1");
            }

        }

        public Tuple<String, String, String> Fetch_data_snf(int id)
        {
            con.Open();
            String query = "Select start_snf,end_snf,increment from cow_snf where id = '" + id + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String a = reader["start_snf"].ToString();
                String b = reader["end_snf"].ToString();
                String c = reader["increment"].ToString();
                con.Close();
                return new Tuple<String, String, String>(a, b, c);
            }
            else
            {
                con.Close();
                return new Tuple<String, String, String>("a", "b", "-1");
            }

        }

        public Tuple<String, String, String> Fetch_data_fat2(int id)
        {
            con.Open();
            String query = "Select start_fat,end_fat,increment from buffalo_fat where id = '" + id + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String a = reader["start_fat"].ToString();
                String b = reader["end_fat"].ToString();
                String c = reader["increment"].ToString();
                con.Close();
                return new Tuple<String, String, String>(a, b, c);
            }
            else
            {
                con.Close();
                return new Tuple<String, String, String>("a", "b", "-1");
            }

        }

        public Tuple<String, String, String> Fetch_data_snf2(int id)
        {
            con.Open();
            String query = "Select start_snf,end_snf,increment from buffalo_snf where id = '" + id + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String a = reader["start_snf"].ToString();
                String b = reader["end_snf"].ToString();
                String c = reader["increment"].ToString();
                con.Close();
                return new Tuple<String, String, String>(a, b, c);
            }
            else
            {
                con.Close();
                return new Tuple<String, String, String>("a", "b", "-1");
            }

        }


        public DataTable display(int id)
        {
            String qry;
            con.Open();

            if(id == 1)
            {
                qry = "Select * from cow_fat";
            }
            else if(id == 2)
            {
                qry = "Select * from cow_snf";
            }
            else if( id == 3)
            {
                qry = "Select * from buffalo_fat";
            }
            else
            {
                qry = "Select * from buffalo_snf";
            }




            adpt = new SqlDataAdapter(qry, con);
            bld = new SqlCommandBuilder(adpt);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public int update_data(int id, float start, float end, float incr, int type)
        {
            try
            {
                con.Open();
                string query = "";
                if(type == 1)
                {
                    query = "update cow_fat set start_fat='" + start + "', end_fat='" + end + "', increment = '" + incr + "' where id=" + id + "";
                }
                else if(type == 2)
                {
                    query = "update cow_snf set start_snf='" + start + "', end_snf='" + end + "', increment = '" + incr + "' where id=" + id + "";
                }
                else if( type == 3)
                {
                    query = "update buffalo_fat set start_fat='" + start + "', end_fat='" + end + "', increment = '" + incr + "' where id=" + id + "";
                }
                else if(type == 4)
                {
                    query = "update buffalo_snf set start_snf='" + start + "', end_snf='" + end + "', increment = '" + incr + "' where id=" + id + "";
                }
                
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

        public Tuple<String, String> Fetch_rate(int id)
        {
            con.Open();
            String query = "Select rate from start_rate where id = '" + id + "'";
            String b = "";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String a = reader["rate"].ToString();
                con.Close();
                return new Tuple<String,String>(a,b);
            }
            else
            {
                con.Close();
                return new Tuple<String, String>("a", "-1");
            }

        }


        public int update_rate(int id,float rate)
        {
            try
            {
                con.Open();
                string query = "";
                query = "update start_rate set rate='" + rate + "' where id=" + id + "";

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

    }
}
