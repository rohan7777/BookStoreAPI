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
        // Logic to delete current orderlines and update BookTable quantity
        public void SaveCartFunction(List<SaveCartModel> orderlineList)
        {
            var con = @"Data Source=IL013449;Initial Catalog=Test;User ID=sa;Password=~$ystem32";       //Connection String
            SqlConnection myConnection = new SqlConnection(con);
            myConnection.Open();

            SqlCommand getTotalCountOfOrderLines = new SqlCommand("select count(*) from OrderLines where UserID = " + orderlineList[0].UserID.ToString() + "", myConnection);
            int countOfOrderlines = Convert.ToInt32(getTotalCountOfOrderLines.ExecuteScalar());

            List<int> listOfProductsInOldCart = new List<int>();

            SqlCommand getProductIDsFromCurOrdLine = new SqlCommand("select ProductID from OrderLines where UserID = " + orderlineList[0].UserID, myConnection);
            using (SqlDataReader myReader = getProductIDsFromCurOrdLine.ExecuteReader())
            {
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int temp = myReader.GetInt32(myReader.GetOrdinal("ProductID"));
                        listOfProductsInOldCart.Add(temp);
                    }
                }
            }


            for (int i = 0; i < listOfProductsInOldCart.Count; i++)
            {
                try
                {
                    SqlCommand fetchCurBookQuantTable = new SqlCommand("select Quantity from BookTable where ID = " + listOfProductsInOldCart[i] + "", myConnection);
                    int currQuantityInTable = (int)fetchCurBookQuantTable.ExecuteScalar();
                    SqlCommand fetchOldOrdrelineProdQuant = new SqlCommand("select Quantity from OrderLines where ProductID = " + listOfProductsInOldCart[i].ToString() + " " + " and UserID = " + orderlineList[0].UserID.ToString() + "", myConnection);
                    int oldOrderlineProdQuant = Convert.ToInt32(fetchOldOrdrelineProdQuant.ExecuteScalar());
                    int finalQuant = currQuantityInTable + oldOrderlineProdQuant;
                    SqlCommand updateBookQuant = new SqlCommand("update BookTable set Quantity = " + finalQuant.ToString() + " where ID = " + listOfProductsInOldCart[i] + "", myConnection);
                    SqlCommand deleteCommand = new SqlCommand("delete from OrderLines where UserID = " + orderlineList[0].UserID + " and ProductID = " + listOfProductsInOldCart[i] +"", myConnection);
                    deleteCommand.ExecuteNonQuery();
                    updateBookQuant.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            // Logic to delete orderlines and update BookTable complete




            
                /* Apparantly redundant code
                 * 
                 * for (int i = 0; i < countOfOrderlines; i++)
                {
                    try
                    {
                        SqlCommand fetchCurBookQuantTable = new SqlCommand("select Quantity from BookTable where ID = " + orderlineList[i].ProductID + "", myConnection);
                        int currQuantityInTable = (int)fetchCurBookQuantTable.ExecuteScalar();
                        SqlCommand fetchOldOrdrelineProdQuant = new SqlCommand("select Quantity from OrderLines where ProductID = " + orderlineList[i].ProductID.ToString() + " " + " and UserID = " + orderlineList[i].UserID.ToString() + "", myConnection);
                        int oldOrderlineProdQuant = Convert.ToInt32(fetchOldOrdrelineProdQuant.ExecuteScalar());


                        int finalQuant = currQuantityInTable - oldOrderlineProdQuant;
                        SqlCommand updateBookQuant = new SqlCommand("update BookTable set Quantity = " + finalQuant.ToString() + " where ID = " + orderlineList[i].ProductID.ToString() + "", myConnection);

                        updateBookQuant.ExecuteNonQuery();
                    }
                    catch(Exception e1)
                    {
                        Console.WriteLine(e1);
                    }
                }*/

            /*

        for (int i = 0; i < orderlineList.Count; i++)
        {
            SqlCommand fetchCurBookQuantTable = new SqlCommand("select Quantity from BookTable where ID = " + orderlineList[i].ProductID + "", myConnection);
            int currQuantityInTable = (int)fetchCurBookQuantTable.ExecuteScalar();
            SqlCommand fetchOldOrdrelineProdQuant = new SqlCommand("select Quantity from OrderLines where ProductID = " + orderlineList[i].ProductID.ToString() + " " + " and UserID = " + orderlineList[i].UserID.ToString() + "",myConnection);
            int oldOrderlineProdQuant = Convert.ToInt32(fetchOldOrdrelineProdQuant.ExecuteScalar());


            int finalQuant = currQuantityInTable + oldOrderlineProdQuant;
            SqlCommand updateBookQuant = new SqlCommand("update BookTable set Quantity = " + finalQuant.ToString() + " where ID = " + orderlineList[i].ProductID.ToString() + "", myConnection);

            updateBookQuant.ExecuteNonQuery();
        }*/



            

            for (int i = 0; i < orderlineList.Count; i++)
            {
                SqlCommand fetchCurBookQuantTable = new SqlCommand("select Quantity from BookTable where ID = " + orderlineList[i].ProductID + "", myConnection);
                int currQuantityInTable = (int)fetchCurBookQuantTable.ExecuteScalar();
                int finalQuant = currQuantityInTable - Convert.ToInt32(orderlineList[i].Quantity);
                SqlCommand updateBookQuant = new SqlCommand("update BookTable set Quantity = " + finalQuant.ToString() + " where ID = " + orderlineList[i].ProductID.ToString() + "", myConnection);

                SqlCommand insertCommand = new SqlCommand("insert into OrderLines(OrderID,UserID,ProductID,Quantity) values(" + orderlineList[i].OrderID.ToString() + "," + orderlineList[i].UserID.ToString() + "," + orderlineList[i].ProductID.ToString() + "," + orderlineList[i].Quantity.ToString() + ");", myConnection);
                updateBookQuant.ExecuteNonQuery();
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}