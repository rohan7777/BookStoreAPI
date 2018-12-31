using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.CRUD
{
    public class Login
    {
        public bool handleLogin(LoginModel val)
        {
            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM LoginTable", myConnection);
                myConnection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if(reader["email"].ToString() == val.email)
                        {
                            if(reader["password"].ToString() == val.password)
                            {
                                return true;
                            }
                        }
                    }
                    reader.NextResult();
                }
            }
            return false;
        }
    }
}