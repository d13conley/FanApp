﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello.Data;
using Hello.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hello.Controllers
{
	
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
		public ApplicationDbContext _db;
		public ValuesController( ApplicationDbContext db)
		{
			_db = db;
		}
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<Post> Get(string id)
        {
			var posts = _db.Post.Where(u => u.ApplicationUserId == id).ToList();
			return posts;
		}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
