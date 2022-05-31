using System;

namespace TweetAPP.Models
{
    public class UserTweets
    {
        public string UserName { get; set; }
        public string Tweets { get; set; }
        public string Imagename { get; set; }
        public DateTime TweetDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Likes { get; set; }
    }
}
