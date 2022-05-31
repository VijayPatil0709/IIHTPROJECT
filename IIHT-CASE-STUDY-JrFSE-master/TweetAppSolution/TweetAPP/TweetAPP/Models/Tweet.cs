using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TweetAPP.Models
{
    
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }

       
        public string Tweets { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime TweetDate { get; set; }

        public IList<Comment> Comments { get; set; }

        public int Likes { get; set; }
    }
}
