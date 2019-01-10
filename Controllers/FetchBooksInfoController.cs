using BookStoreAPI.CRUD;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class FetchBooksInfoController : ApiController
    {
        // GET: api/FetchBooksInfo
        //public IEnumerable<string> Get()
        public List<FetchBooksInfoModel> Get()
        {
            FetchBooksInfoLogic obj = new FetchBooksInfoLogic();
            obj.returnBookInfo();
            return obj.returnBookInfo();
        }

        // GET: api/FetchBooksInfo/5
        public List<FetchBooksInfoModel> Get(int id)
        {
            FetchBooksInfoLogic obj = new FetchBooksInfoLogic();
            obj.returnBookInfo();
            return obj.returnBookInfo(id);
        }

        // POST: api/FetchBooksInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FetchBooksInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FetchBooksInfo/5
        public void Delete(int id)
        {
        }
    }
}
