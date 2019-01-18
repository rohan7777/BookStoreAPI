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
    public class GetCategoryController : ApiController
    {
        // GET: api/GetCategory
        public List<CategoryModel> Get()
        {
            GetCategoryLogic obj = new GetCategoryLogic();
            return obj.GetCategory();

        }

        // GET: api/GetCategory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GetCategory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetCategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetCategory/5
        public void Delete(int id)
        {
        }
    }
}
