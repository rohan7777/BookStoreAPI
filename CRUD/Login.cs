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
        public LoginModel handleLogin(LoginModel val)
        {
            LoginModel l1 = new LoginModel();
            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            string commandString = "select * from Users where username = \'" + val.username.ToString() + "\' and password = \'" + val.password.ToString() + "\'";
            SqlCommand command = new SqlCommand(commandString, myConnection);
            SqlDataReader myreader;
            myConnection.Open();
            myreader = command.ExecuteReader();
            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    l1.AuthenticationStatus = true;
                    l1.firstname = myreader[1].ToString();
                    l1.lastname = myreader[2].ToString();
                    l1.username = myreader[3].ToString();
                    l1.password = null;
                    l1.ID =  myreader[0].ToString();
                    l1.isAdmin = myreader[6].ToString();
                    
                }
            }
            else
            {
                l1.AuthenticationStatus = false;
            }
            return l1;
        }
    }
}