using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using VoteApi.Data;
using VoteApi.Models;

namespace VoteApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RestaurantController : ControllerBase
    {
        private ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurants;
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant)
        {
            if (restaurant == null)
                return BadRequest();

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return Ok("Restaurante cadastrado!");
        }
    }
}
