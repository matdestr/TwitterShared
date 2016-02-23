using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces;

namespace XamarinTestShared.Tweet
{
    public class TweetHelper : ITweetHelper
    {
        public ITweet PublishTweet(string text)
        {
            var publishedTweet = Tweetinvi.Tweet.PublishTweet(text);
            return publishedTweet;
        }

        public ITweet PublishReplyTweet(string text, long tweetIdtoReplyTo)
        {
            var tweetToReplyTo = Tweetinvi.Tweet.GetTweet(tweetIdtoReplyTo);
            var textToPublish = string.Format("@{0} {1}", tweetToReplyTo.CreatedBy.ScreenName, text);
            var publishedTweet = Tweetinvi.Tweet.PublishTweetInReplyTo(textToPublish, tweetIdtoReplyTo);
            return publishedTweet;
        }

        public int GetTweetLength(string text)
        {
            return text.TweetLength();
        }

        public ITweet Retweet(long tweetId)
        {
            var retweet = Tweetinvi.Tweet.PublishRetweet(tweetId);
            return retweet;
        }

        public bool DeleteTweet(long tweetId)
        {
            var success = Tweetinvi.Tweet.DestroyTweet(tweetId);
            return success;
        }

        public bool FavouriteTweet(long tweetId)
        {
            var success = Tweetinvi.Tweet.FavoriteTweet(tweetId);
            return success;
        }

        public IEnumerable<ITweet> Search(string text)
        {
            var matchingTweets = Tweetinvi.Search.SearchTweets(text);
            return matchingTweets;
        }
    }
}
