﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyManagementSoftware
{
    internal class sales_class
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-39R8HFFR\SQLEXPRESS;Initial Catalog=dairymanagement;Integrated Security=True");
        SqlCommand cmd;

        SqlCommandBuilder bld;
        SqlDataAdapter adpt;

        public int insertdata(int id, String date, String item_type, int qnt, int price,  int tot_amt)
        {
            try
            {
                con.Open();
                String query = "insert into sales_details values(" + id + ",'" + date + "','" + item_type + "','" + qnt + "','" + price + "', '" + tot_amt + "')";
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


        public DataTable display(int id, String Date1, String Date2)
        {
            String qry;
            con.Open();

            if (Date1 == Date2)
            {
                qry = "select * from sales_details where Member_id = '" + id + "'";
            }
            else
            {
                qry = "select * from sales_details where Member_id = '" + id + "' and Date between '" + Date1 + "' and '" + Date2 + "'";
            }

            adpt = new SqlDataAdapter(qry, con);
            bld = new SqlCommandBuilder(adpt);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable display()
        {
            String qry;
            con.Open();
            qry = "select * from sales_details";
            adpt = new SqlDataAdapter(qry, con);
            bld = new SqlCommandBuilder(adpt);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public String sum_sales(int id, String Date1, String Date2)
        {
            String str;
            con.Open();
            String qry = "Select sum(Total_Amount) as sum from sales_details where Member_id = '" + id + "' and Date between '" + Date1 + "' and '" + Date2 + "'";
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
