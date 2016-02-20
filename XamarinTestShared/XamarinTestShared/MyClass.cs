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
            Tweetinvi.Auth.SetUserCredentials("N8U7yLDCRbZqJpo2NstN4bTJT", "VIf5sT9pmpsayeRBUc1MrGRS4zq7qzdDktcMmCLS1aMlGuLZmr", "1065192774-TBevJ5RuGGXUAxpX28EsaNjc6fkjpCOCv4xpo5U", "09q2JmCag9gGeIz29jCjQKTS4NVu6tsI7900V1fXjBiI8");

        }

        public static ITweet publishTweet()
        {
            var tweet = Tweet.PublishTweet("Hello Jelle Spoelders!");
            return tweet;
        }

        public static IEnumerable<ITweet> getHomeLine()
        {
            var user = User.GetLoggedUser();
            var tweets = Timeline.GetHomeTimeline();
            return tweets;
        }

	    public static void Retweet(long id)
	    {
	        Tweet.PublishRetweet(id);
	    }

	    public static void Answer(string text,long id)
	    {
	        Tweet.PublishTweetInReplyTo(text, id);
	    }
    }
}

