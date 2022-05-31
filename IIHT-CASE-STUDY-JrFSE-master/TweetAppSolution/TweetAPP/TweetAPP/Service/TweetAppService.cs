using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TweetAPP.Models;
using TweetAPP.Repositories;

namespace TweetAPP.Service
{
    public class TweetAppService : ITweetAppService
    {
        private readonly ITweetRepository tweetRepository;
        private ILogger<TweetAppService> logger;
        public TweetAppService(ITweetRepository tweetRepository, ILogger<TweetAppService> logger)
        {
            this.tweetRepository = tweetRepository;
            this.logger = logger;
        }
        public async Task<int> Comments(string comment, string username, string userName, string tweet)
        {
            try
            {
                DateTime date = DateTime.Now;
                var result = await this.tweetRepository.Comments(comment, username, userName, tweet, date);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while posting comment");
                throw;
            }
        }
        public async Task<string> ForgotPassword(string emailId, string password)
        {
            try
            {
                string message = string.Empty;
                if (password != null)
                {
                    password = this.EncryptPassword(password);
                }

                var result = await this.tweetRepository.ForgotPassword(emailId, password);
                if (result)
                {
                    message = "Changed Password";
                }
                else
                {
                    message = "Failed to change password";
                }

                return message;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while reseting password");
                throw;
            }
        }
        public async Task<List<UserTweets>> GetAllTweets()
        {
            try
            {
                var result = await this.tweetRepository.GetAllTweets();
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }
        public async Task<IList<RegisteredUser>> GetAllUsers()
        {
            try
            {
                var result = await this.tweetRepository.GetAllUsers();
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving all registered users");
                throw;
            }
        }
        public async Task<List<UserTweets>> GetTweetsByUser(string username)
        {
            try
            {
                var result = await this.tweetRepository.GetTweetsByUser(username);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving tweets by user");
                throw;
            }
        }
        public async Task<User> GetUserProfile(string username)
        {
            try
            {
                var result = await this.tweetRepository.GetUserProfile(username);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving user");
                throw;
            }
        }
        public async Task<int> Likes(string username, string tweet)
        {
            try
            {
                var result = await this.tweetRepository.Likes(username, tweet);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while getting likes");
                throw;
            }
        }
        public async Task<string> PostTweet(Tweet tweet)
        {
            try
            {
                string message = string.Empty;
                var result = await this.tweetRepository.PostTweet(tweet);
                if (result > 0)
                {
                    message = "Tweet Posted Successfully";
                }
                else
                {
                    message = "Error occured while posting the tweet";
                }

                return message;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while posting tweets");
                throw;
            }
        }
        public async Task<string> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            try
            {
                string message = string.Empty;
                if (newPassword != null && oldpassword != null)
                {
                    newPassword = this.EncryptPassword(newPassword);
                    oldpassword = this.EncryptPassword(oldpassword);
                }

                var result = await this.tweetRepository.UpdatePassword(emailId, oldpassword, newPassword);
                if (result)
                {
                    message = "Updated Successfully";
                }
                else
                {
                    message = "Update Failed";
                }

                return message;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while updating password");
                throw;
            }
        }
        public async Task<User> UserLogin(string emailId, string password)
        {
            try
            {
                if (password != null)
                {
                    password = this.EncryptPassword(password);
                }

                var result = await this.tweetRepository.Login(emailId, password);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while logging in");
                throw;
            }
        }
        public async Task<string> Register(User users)
        {
            try
            {
                if (users != null)
                {
                    string message = string.Empty;
                    var validate = await this.tweetRepository.ValidateEmailId(users.EmailId);
                    var uservalidate = await this.tweetRepository.ValidateName(users.FirstName, users.Username);
                    if (validate == null && uservalidate == null)
                    {
                        users.Password = this.EncryptPassword(users.Password);
                        var result = await this.tweetRepository.Register(users);
                        if (result > 0)
                        {
                            message = "User Registered successfully";
                        }
                        else
                        {
                            message = "User Registration failed";
                        }
                    }
                    else
                    {
                        if (validate != null)
                        {
                            message = "EmailId is already used";
                        }
                        else
                        {
                            message = "Username is already taken";
                        }
                    }

                    return message;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering");
                throw;
            }
        }

        public async Task<List<UserComments>> GetComments(string username, string tweet)
        {
            try
            {
                var result = await this.tweetRepository.GetComments(username, tweet);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while comments");
                throw;
            }
        }

        public async Task<string> DeleteTweet(string username, string tweet)
        {
            try
            {
                string message = string.Empty;
                var result = await this.tweetRepository.DeleteTweet(username, tweet);
                if (result>0)
                {
                    return message = "Tweet Deleted";
                }
                else
                {
                    return message = "Failed to Delete";
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while comments");
                throw;
            }
        }

        private string EncryptPassword(string password)
        {
            string message = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            message = Convert.ToBase64String(encode);
            return message;
        }
    }
}