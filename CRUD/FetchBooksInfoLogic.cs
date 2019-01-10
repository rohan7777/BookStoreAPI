using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace BookStoreAPI.CRUD
{
    public class FetchBooksInfoLogic
    {
        public List<FetchBooksInfoModel> returnBookInfo ()                                              //This function will return List of FetchBooksInfoModel upon calling
        {       
            List<FetchBooksInfoModel> l1 = new List<FetchBooksInfoModel>();                             //Creates a list which will hold all the records from database
            FetchBooksInfoModel temp = new FetchBooksInfoModel();                                       //Created an object for FetchBooksInfoModel

            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            SqlCommand command = new SqlCommand("select * from BookTable", myConnection);
            SqlDataReader myreader;
            myConnection.Open();
            myreader = command.ExecuteReader();
            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    l1.Add(new FetchBooksInfoModel() { ID = Convert.ToInt32(myreader[0]), Name = myreader[1].ToString(), Author = myreader[2].ToString(), Description = myreader[3].ToString(), Price = Convert.ToSingle(myreader[4]), Quantity = Convert.ToInt32(myreader[5]), CategoryID = Convert.ToInt32(myreader[6]), IconURL = myreader[7].ToString() });
                }
            }
            return l1;
        }
    }
}