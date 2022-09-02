using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VoteApi.Data;
using VoteApi.Models;

namespace VoteApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        [HttpGet("{id}")]
        public IEnumerable<User> GetByEmail(Guid id)
        {
            return _context.Users.Where(u => u.Id == id);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user == null)
                return BadRequest();

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Colaborador cadastrado!");
        }
    }
}
