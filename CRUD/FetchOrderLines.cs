using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Models;
using System.Data.SqlClient;

namespace BookStoreAPI.CRUD
{
    public class FetchOrderLines
    {
        // Fetches orderlines based on userID
        public List<OrderLinesModel> FetchOrderLinesLogic(int id)
        {
            List<OrderLinesModel> l1 = new List<OrderLinesModel>();
            OrderLinesModel temp = new OrderLinesModel();

            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            SqlCommand command = new SqlCommand("select * from OrderLines where USERID = " + id + "", myConnection);
            SqlDataReader myreader;
            myConnection.Open();
            myreader = command.ExecuteReader();
            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    l1.Add(new OrderLinesModel() { ID = myreader[0].ToString(), OrderID = myreader[1].ToString(), UserID = myreader[2].ToString(), ProductID = myreader[3].ToString(), Quantity = myreader[4].ToString() });// ID = Convert.ToInt32(myreader[0]), Name = myreader[1].ToString(), Author = myreader[2].ToString(), Description = myreader[3].ToString(), Price = Convert.ToSingle(myreader[4]), Quantity = Convert.ToInt32(myreader[5]), CategoryID = Convert.ToInt32(myreader[6]), IconURL = myreader[7].ToString() });
                }
            }
            return l1;



        }
    }
}