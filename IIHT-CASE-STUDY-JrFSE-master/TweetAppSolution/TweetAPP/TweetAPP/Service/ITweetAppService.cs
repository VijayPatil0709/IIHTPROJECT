using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetAPP.Models;

namespace TweetAPP.Service
{
   
    public interface ITweetAppService
    {
        Task<string> Register(User users);
        Task<User> UserLogin(string Username, string password);
        Task<List<UserTweets>> GetAllTweets();
        Task<List<UserTweets>> GetTweetsByUser(string username);
        Task<IList<RegisteredUser>> GetAllUsers();
        Task<string> PostTweet(Tweet tweet);
        Task<string> UpdatePassword(string emailId, string oldpassword, string newPassword);
        Task<string> ForgotPassword(string emailId, string password);
        Task<int> Likes(string username, string tweet);
        Task<List<UserComments>> GetComments(string username, string tweet);
        Task<int> Comments(string comment, string username, string userName, string tweet);
        Task<string> DeleteTweet(string username, string tweet);
        Task<User> GetUserProfile(string username);

    }
}
