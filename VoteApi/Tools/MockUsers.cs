using System.Collections.Generic;
using VoteApi.Data;
using VoteApi.Models;

namespace VoteApi.Tools
{
    public class MockUsers
    {
        private readonly ApplicationDbContext _context;

        public MockUsers(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddInitialUsers()
        {
            List<User> Users = new List<User>
            {
                new User { Name = "Pedro", Email = "pedro@test.com" },
                new User { Name = "Ana", Email = "ana@test.com" },
                new User { Name = "Hyago", Email = "hyago@test.com" },
                new User { Name = "João Pedro", Email = "jp@test.com"}
            };

            _context.Users.AddRange(Users);
            _context.SaveChanges();
        }
    }
}
