using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VoteApi.Data;
using VoteApi.Models;

namespace VoteApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ResultController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Restaurant Get()
        {
            DateTime thisDay = DateTime.Now;
            var restaurants = _context.Restaurants;
            Restaurant result = new Restaurant();
            int votesMax = 0;

            restaurants.ForEachAsync(async restaurant =>
            {
                var votes = _context.Votes.Count(v => v.CreatedDate.Date == thisDay.Date && v.Restaurant == restaurant.Id.ToString());
                if (votes > votesMax)
                {
                    votesMax = votes;
                    result = restaurant;
                }
            });


            return result;
        }
    }
   
}
