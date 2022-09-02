using System.Collections.Generic;
using System.Linq.Expressions;
using VoteApi.Data;
using VoteApi.Models;

namespace VoteApi.Tools
{
    public class MockRestaurants
    {
        private readonly ApplicationDbContext _context;

        public MockRestaurants(ApplicationDbContext context)
        {
            _context = context;
        }  
        
        public void AddInitialRestaurants()
        {
            List<Restaurant> Restaurants = new List<Restaurant>
            {
                new Restaurant { Name = "Cheiro Verde" },
                new Restaurant { Name = "Grego" },
                new Restaurant { Name = "Mau Nenhum" }
            };

            _context.Restaurants.AddRange(Restaurants);
            _context.SaveChanges();
        }
    }
}
