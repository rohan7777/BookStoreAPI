using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class FetchBooksInfoModel
    {
        // Model for returning all the details of the book in the database
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public string IconURL { get; set; }
    }
}