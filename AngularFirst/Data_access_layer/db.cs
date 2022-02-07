using AngularFirst.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AngularFirst.Data_access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AngularCrud"].ConnectionString);

        //Add record

        public void Add_record(Register re)
        {
            SqlCommand com = new SqlCommand("Sp_register",con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Email", re.Email);
            com.Parameters.AddWithValue("@Password", re.Password);
            com.Parameters.AddWithValue("@Name", re.Name);
            com.Parameters.AddWithValue("@Address", re.Address);
            com.Parameters.AddWithValue("@City", re.City);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_record()
        {
            SqlCommand com = new SqlCommand("Sp_register_get", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Update_record(Register re)
        {
            SqlCommand com = new SqlCommand("Sp_register_Update", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Email", re.Email);
            com.Parameters.AddWithValue("@Password", re.Password);
            com.Parameters.AddWithValue("@Name", re.Name);
            com.Parameters.AddWithValue("@Address", re.Address);
            com.Parameters.AddWithValue("@City", re.City);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_recordbyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_byid", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();

            da.Fill(ds);
            return ds;
        }
        public void Deletedata(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_delete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);
            con.Open();
            com.ExecuteReader();
            con.Close();
        }
    }
}