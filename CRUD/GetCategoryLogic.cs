using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Models;
using System.Data.SqlClient;

namespace BookStoreAPI.CRUD
{
    public class GetCategoryLogic
    {
        public List<CategoryModel> GetCategory()
        {
            List<CategoryModel> l1 = new List<CategoryModel>();
            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            SqlCommand command = new SqlCommand("select * from Category order by ID", myConnection);
            SqlDataReader myreader;
            myConnection.Open();
            myreader = command.ExecuteReader();
            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    l1.Add(new CategoryModel() { ID = Convert.ToInt32(myreader[0]), Category = myreader[1].ToString()});
                }
            }
            return l1;
        }
    }
}