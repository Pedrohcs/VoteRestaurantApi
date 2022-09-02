using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApi.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Restaurant()
        {
            Id = Guid.NewGuid();
        }
    }
}
