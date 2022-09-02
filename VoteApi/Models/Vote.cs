using System;

namespace VoteApi.Models
{
    public class Vote
    {
        public Guid Id { get; set; }
        public string Restaurant { get; set; }
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }


        public Vote()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }
}
