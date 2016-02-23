using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace XamarinTestShared.User
{
    public class UserHelper : IUserHelper
    {
        public IUser GetUserById(long userId)
        {
            var user = Tweetinvi.User.GetUserFromId(userId);
            return user;
        }

        public IUser GetUserByScreenName(string screenName)
        {
            var user = Tweetinvi.User.GetUserFromScreenName(screenName);
            return user;
        }

        public IEnumerable<IUser> SearchUser(string text)
        {
            var users = Search.SearchUsers(text);
            return users;
        }
    }
}
