using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Training_Calendar.Models
{
    public class Technical_Context_Db
    {
        string cs = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        //Display
        public List<Technical_Model_Db> ListAll()
        {
            List<Technical_Model_Db> list = new List<Technical_Model_Db>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_Display_Technical", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Technical_Model_Db
                    {
                        Training_Id = Convert.ToInt32(rdr["Training_Id"]),
                        //DateString= Convert.ToString(rdr["Date"]),
                        DateString = Convert.ToDateTime(rdr["Date"]).ToString("MMMM dd yyyy"),
                       // Date = Convert.ToDateTime(rdr["Date"]),

                        Program = Convert.ToString(rdr["Program"]),
                        Facillator = Convert.ToString(rdr["Facillator"]),
                        Details = Convert.ToString(rdr["Details"])
                    });
                }
                return list;
            }
        }

        //Insert
        public int Add(Technical_Model_Db T)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                //SqlCommand com = new SqlCommand("Insert_Update_Technical", con);

                SqlCommand com = new SqlCommand("Sp_Test", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Training_Id", T.Training_Id);
                com.Parameters.AddWithValue("@Date", T.Date);
                com.Parameters.AddWithValue("@Program", T.Program);
                com.Parameters.AddWithValue("@Facillator", T.Facillator);
                com.Parameters.AddWithValue("@Details", T.Details);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Update
        //public int Update(Technical_Model_Db T)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //       SqlCommand com = new SqlCommand("Sp_Insert_Update_Test", con);
        //        //SqlCommand com = new SqlCommand("Insert_Update_Technical", con);

        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Training_Id", T.Training_Id);
        //        com.Parameters.AddWithValue("@Date", T.Date);
        //        com.Parameters.AddWithValue("@Program", T.Program);
        //        com.Parameters.AddWithValue("@Facillator", T.Facillator);
        //        com.Parameters.AddWithValue("@Details", T.Details);
        //        com.Parameters.AddWithValue("@Action", "Update");
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        //}




        public int Update(Technical_Model_Db T)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_Insert_Update_Test", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Training_Id", T.Training_Id);
                com.Parameters.AddWithValue("@Date", T.Date);
                com.Parameters.AddWithValue("@Program", T.Program);
                com.Parameters.AddWithValue("@Facillator", T.Facillator);
                com.Parameters.AddWithValue("@Details", T.Details);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }




        //Delete
        //public int Delete(int ID)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();

        //        SqlCommand com = new SqlCommand("Sp_Delete_Test", con);
        //        //SqlCommand com = new SqlCommand("Sp_Delete_Technical", con);

        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Training_Id", ID);
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        //}


        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_Delete_Test", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        }
}