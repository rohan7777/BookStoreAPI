using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.CRUD
{
    public class SaveCartLogic
    {
        public void SaveCartFunction(List<SaveCartModel> orderlineList)
        {



            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            SqlCommand deleteCommand = new SqlCommand("delete from OrderLines where UserID = " + orderlineList[0].UserID +"", myConnection);
            myConnection.Open();
            deleteCommand.ExecuteNonQuery();

            for(int i=0; i<orderlineList.Count;i++)
            {
                //SqlCommand insertCommand = new SqlCommand("insert into OrderLines(OrderID,UserID,ProductID,Quantity) values(1,2,3,4)");
                SqlCommand insertCommand = new SqlCommand("insert into OrderLines(OrderID,UserID,ProductID,Quantity) values(" + orderlineList[i].OrderID.ToString() + "," + orderlineList[i].UserID.ToString() + "," + orderlineList[i].ProductID.ToString() + "," + orderlineList[i].Quantity.ToString()  + ");", myConnection);
                insertCommand.ExecuteNonQuery();
            }




















/*
            SqlDataReader myreader;
            
            
            myreader = deleteCommand.ExecuteReader();
            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    l1.Add(new FetchBooksInfoModel() { ID = Convert.ToInt32(myreader[0]), Name = myreader[1].ToString(), Author = myreader[2].ToString(), Description = myreader[3].ToString(), Price = Convert.ToSingle(myreader[4]), Quantity = Convert.ToInt32(myreader[5]), CategoryID = Convert.ToInt32(myreader[6]), IconURL = myreader[7].ToString() });
                }
            }*/
        }
    }
}