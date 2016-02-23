using System;
using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;

namespace XamarinTestShared
{
	public class MyClass
	{
		public MyClass ()
		{
		}

        public static void Auth()
        {
            Tweetinvi.Auth.SetUserCredentials("Kfu7pQMNgY1KJIVGiaKuGYsRj", "1URdqiMxNTKBfXp2wnlXbft9iSlhtmGaHyIBBUPwJuKn6ZTMBm", "1065192774-kvjhsK9EFcgVJ5oEzmJlENrzXTtpZIRku5LAiB4", "WM4WPz0B66BQH0fu6iTsSVRN6FkEoxH6mrXn1GGwF50Yc");

        }

        public static ITweet publishTweet()
        {
            var tweet = Tweetinvi.Tweet.PublishTweet("Hello Jelle Spoelders!");
            return tweet;
        }

        public static IEnumerable<ITweet> getHomeLine()
        {
            var user = Tweetinvi.User.GetLoggedUser();
            var tweets = Tweetinvi.Timeline.GetUserTimeline(user);
            return tweets;
        }

	    public static void Retweet(long id)
	    {
            Tweetinvi.Tweet.PublishRetweet(id);
	    }

	    public static void Answer(string text,long id)
	    {
            Tweetinvi.Tweet.PublishTweetInReplyTo(text, id);
	    }
    }
}

