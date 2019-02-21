using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreAPI.Models;
using BookStoreAPI.CRUD;

namespace BookStoreAPI.Controllers
{
    public class SaveCartController : ApiController
    {
        // GET: api/SaveCart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SaveCart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SaveCart
        /*public void Post([FromBody]string value)
        {
        }*/
        
        public void Post(List<SaveCartModel> obj)
        {
            SaveCartLogic o = new SaveCartLogic();
            o.SaveCartFunction(obj);
            return;
        }
        // PUT: api/SaveCart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SaveCart/5
        public void Delete(int id)
        {
        }
    }
}
