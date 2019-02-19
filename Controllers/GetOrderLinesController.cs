using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreAPI.CRUD;

namespace BookStoreAPI.Controllers
{
    public class GetOrderLinesController : ApiController
    {
        // GET: api/GetOrderLines
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetOrderLines/5
        public List<OrderLinesModel> Get(int id)
        {
            OrderLinesModel obj = new OrderLinesModel();
            FetchOrderLines object1 = new FetchOrderLines();
            return object1.FetchOrderLinesLogic(id);
            
        }

        // POST: api/GetOrderLines
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetOrderLines/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetOrderLines/5
        public void Delete(int id)
        {
        }
    }
}
