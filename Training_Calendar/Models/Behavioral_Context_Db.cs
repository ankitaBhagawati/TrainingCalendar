using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Training_Calendar.Models
{
    public class Behavioral_Context_Db
    {

        string cs = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        //Display
        public List<Behavioral_Model_Db> ListAll()
        {
            List<Behavioral_Model_Db> list = new List<Behavioral_Model_Db>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_Display_Behavioral", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Behavioral_Model_Db
                    {
                        Training_Id = Convert.ToInt32(rdr["Trainig_Id"]),
                       // Date = Convert.ToDateTime(rdr["Date"]),
                        DateString = Convert.ToDateTime(rdr["Date"]).ToString("MMMM dd"),
                        Program = Convert.ToString(rdr["Program"]),
                        Details = Convert.ToString(rdr["Details"])
                    });
                }
                return list;
            }
        }
        //Insert
        public int Add(Behavioral_Model_Db B)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insert_Update_Behavioral", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Training_Id", B.Training_Id);
                com.Parameters.AddWithValue("@Date", B.Date);
                com.Parameters.AddWithValue("@Program", B.Program);
                com.Parameters.AddWithValue("@Details", B.Details);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Update
        public int Update(Behavioral_Model_Db B)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insert_Update_Behavioral", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Training_Id", B.Training_Id);
                com.Parameters.AddWithValue("@Date", B.Date);
                com.Parameters.AddWithValue("@Program", B.Program);
                com.Parameters.AddWithValue("@Details", B.Details);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        //Delete
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_Delete_Behavioral", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Training_Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        }
}