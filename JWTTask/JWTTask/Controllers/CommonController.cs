using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JWTTask.Models;

namespace JWTTask.Controllers
{
    [Authorize]
    public class CommonController : ApiController
    {
        MVC0705DBEntities db;
        public CommonController()
        {
            db = new MVC0705DBEntities();
        }

        [HttpGet]
        [Route("api/student")]
        public List<student> GetAllStudents()
        {
            return db.students.ToList();
        }

        [HttpGet]
        [Route("api/product")]
        public List<tblproduct> GetAllProducts()
        {
            return db.tblproducts.ToList();
        }
    }
}
