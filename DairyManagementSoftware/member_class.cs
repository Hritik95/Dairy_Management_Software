using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyManagementSoftware
{
    internal class member_class
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-39R8HFFR\SQLEXPRESS;Initial Catalog=dairymanagement;Integrated Security=True");
        SqlCommand cmd;

        SqlCommandBuilder bld;
        SqlDataAdapter adpt;


        public int addData(int id, String name, String address, String ph_no, String date)
        {
            try
            {
                con.Open();
                String query = "insert into member_details values(" + id + ",'" + name + "','" + address + "','" + ph_no + "','" + date + "')";
                cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();
                con.Close();
                return no;
            }catch (Exception e)
            {
                return 0;
            }
        }


        public int updatedata(int id, String name, String address, String ph_no)
        {
            try
            {
                con.Open();
                String query = "update member_details set Name='" + name + "', Address='" + address + "', Phone = '" + ph_no + "' where Member_ID=" + id + "";
                cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();
                con.Close();
                return no;
            } catch (Exception e)
            {
                return 0;
            }
        }



        public int deletedata(int id)
        {
            try
            {
                con.Open();
                String query = "delete from member_details where Member_ID=" + id + "";
                cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();
                con.Close();
                return no;
            } catch(Exception e)
            {
                return 0;
            }
        }


        public DataTable display(int id)
        {
            String qry;
            con.Open();

            if (id == -1)
            {
                qry = "select Member_ID as ID, Name as Name, Address as Address, Phone as Mobile, ac_opening_date as [Account Opening Date] from member_details";
            }
            else
            {
                qry = "select Member_ID as ID, Name as Name, Address as Address, Phone as Mobile, ac_opening_date as [Account Opening Date] from member_details where Member_ID = '" + id + "'";
            }

            adpt = new SqlDataAdapter(qry, con);
            bld = new SqlCommandBuilder(adpt);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public Tuple<String, String, String> Fetch_data(int id)
        {
            con.Open();
            String query = "Select Name,Address,Phone from member_details where Member_ID = '" + id + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String a = reader["Name"].ToString();
                String b = reader["Address"].ToString();
                String c = reader["Phone"].ToString();
                con.Close();
                return new Tuple<String, String, String>(a,b,c);
            }
            else
            {
                con.Close();
                return new Tuple<String, String, String>("a", "b", "-1");
            }
            
        }


    }
}
