﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hello.Services;
using Hello.Data;
using Hello.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hello.Controllers
{
    [Route("api/Users")]
    public class UserController : Controller
    {
        public IUserService _userService;
        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/values
        [HttpGet]
        public List<ApplicationUser> Get()
        {
            return _userService.GetAllUsers();
        }

		// GET api/values/5
		[HttpGet("{email}")]
		public UserVM Get(string email)
		{
			return _userService.GetUserwithpost(email);
		}

		[HttpGet("email/{id}")]
		public UserVM Getid(string id)
		{
			return _userService.GetOtherUserwithpost(id);
		}

		// POST api/values
		[HttpPost]
        public string Post( [FromBody] UserVM user)
        {
			try
			{
				_userService.AddUserProfile(user);
				return "Success!";
			}
			catch
			{
				return "Fail! user was not updated";
			}
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
