using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Core.Interfaces;

namespace XamarinTestShared.Timeline
{
    public class TimelineHelper : ITimelineHelper
    {
        public IEnumerable<ITweet> GetHomeTimeline()
        {
            var loggedUser = Tweetinvi.User.GetLoggedUser();
            var homeTimeline = loggedUser.GetHomeTimeline();
            return homeTimeline;
        }

        public IEnumerable<IMention> GetMentionsTimeline()
        {
            var loggedUser = Tweetinvi.User.GetLoggedUser();
            var mentionsTimeline = loggedUser.GetMentionsTimeline();
            return mentionsTimeline;
        }

        public IEnumerable<ITweet> GetUserTimeline()
        {
            var loggedUser = Tweetinvi.User.GetLoggedUser();
            var userTimeline = loggedUser.GetUserTimeline();
            return userTimeline;
        }
    }
}
