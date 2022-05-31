using System;
using System.ComponentModel.DataAnnotations;

namespace TweetAPP.Models
{
    
    public class UserComments
    {
        public string Username { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
       
        public string Imagename { get; set; }
    }
}
