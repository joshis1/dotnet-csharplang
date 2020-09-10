using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbManager
    {
        string con = Settings.Settings.ConnectionString();


        public DataTable Getdata(string SpName, Dictionary<string,string> dict)
        {
            SqlConnection connection = new SqlConnection(con);

            connection.Open();

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(SpName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                // query in data-adapter 
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //get the result
                foreach (var item in dict)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }

              
                //Here it calls the stored procedure
                // data adapter works with Data Table that's why we have called it
                da.Fill(dt);
           
            }
            catch(Exception ex)
            {
               throw ex;
                //return dt;
            }

            connection.Close();
            return dt;
        }

        public int insertData(string SpName, Dictionary<string,string> valDict)
        {
            SqlConnection connection = new SqlConnection(con);

            DataTable dt = new DataTable();
            int ret = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(SpName, connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                // query in data-adapter 
              
                //get the result
                foreach (var item in valDict)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }


                //Here it calls the stored procedure
                // data adapter works with Data Table that's why we have called it
               
                ret = cmd.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                throw ex;
                //return dt;
            }

            connection.Close();

            return ret;

        }

        public bool SaveData(string SpName, Dictionary<string, string> valDict)
        {
            SqlConnection connection = new SqlConnection(con);

            DataTable dt = new DataTable();
            bool ret = false;
            try
            {
                SqlCommand cmd = new SqlCommand(SpName, connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                // query in data-adapter 

                //get the result
                foreach (var item in valDict)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }


                //Here it calls the stored procedure
                // data adapter works with Data Table that's why we have called it

                ret = (bool)cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
                throw;
                //return dt;
            }

            connection.Close();
            return ret;

        }     

        public string verifyAccount(string SpName, Dictionary<string, string> valDict)
        {
            SqlConnection connection = new SqlConnection(con);
            String passwd;
            DataTable dt = new DataTable();
      
            try
            {
                SqlCommand cmd = new SqlCommand(SpName, connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                // query in data-adapter 

                //get the result
                foreach (var item in valDict)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }


                //Here it calls the stored procedure
                // data adapter works with Data Table that's why we have called it
                passwd = (string)cmd.ExecuteScalar();


                connection.Close();

                if (passwd != null )
                {
                    return passwd;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw ex;
                //return dt;
            }

        }
    }
}
