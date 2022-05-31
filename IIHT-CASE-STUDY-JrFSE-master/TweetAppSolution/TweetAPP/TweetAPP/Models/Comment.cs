using System;
using System.ComponentModel.DataAnnotations;

namespace TweetAPP.Models
{
   
    public class Comment
    {
        [Key]       
        public int Id { get; set; }       
        public int TweetId { get; set; }
        public string Username { get; set; }
        public string Comments { get; set; }

        public DateTime Date { get; set; }
    }
}
