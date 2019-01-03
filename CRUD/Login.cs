using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.CRUD
{
    public class Login
    {
        public bool handleLogin(LoginModel val)
        {
            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            SqlCommand command = new SqlCommand("sp_loginValidation", myConnection);                    //Selection stored procedure as command to be executed
            command.CommandType = System.Data.CommandType.StoredProcedure;                          
            command.Parameters.Add(new SqlParameter("@emailvar", val.email));                           //Adding input parameter
            command.Parameters.Add(new SqlParameter("@passwordvar", val.password));                     //Adding input parameter
            command.Parameters.Add("@resultOut", SqlDbType.Int).Direction = ParameterDirection.Output;  //Adding output parameter
            myConnection.Open();
            command.ExecuteNonQuery();
            int res = Convert.ToInt32(command.Parameters["@resultOut"].Value);                          //Fetch the result value
            if (res == 1)
                return true;
            else
                return false;
        }
    }
}