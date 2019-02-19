using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class OrderLinesModel
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public string ProductID { get; set; }
        public string Quantity { get; set; }
    }
}