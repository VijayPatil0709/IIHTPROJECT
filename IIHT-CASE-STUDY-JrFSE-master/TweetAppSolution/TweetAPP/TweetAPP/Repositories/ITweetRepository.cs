
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetAPP.Models;

namespace TweetAPP.Repositories
{
    public interface ITweetRepository
    {
        Task<int> Register(User users);
        Task<User> Login(string Username, string password);

        Task<List<UserTweets>> GetAllTweets();
        Task<List<UserTweets>> GetTweetsByUser(string username);
        Task<IList<RegisteredUser>> GetAllUsers();
        Task<int> PostTweet(Tweet tweet);
        Task<bool> UpdatePassword(string emailId, string oldpassword, string newPassword);
        Task<bool> ForgotPassword(string emailId, string password);

        Task<User> ValidateEmailId(string emailId);
        Task<User> ValidateName(string firstName, string loginId);
        Task<int> Likes(string username, string tweet);
        Task<List<UserComments>> GetComments(string username, string tweet);
        Task<int> Comments(string comment, string username, string userName, string tweet, DateTime date);

        Task<int> DeleteTweet(string username, string tweet);

        Task<User> GetUserProfile(string username);
    }
}
