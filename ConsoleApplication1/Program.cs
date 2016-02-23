using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using XamarinTestShared;
using XamarinTestShared.Authentication;
using XamarinTestShared.Tweet;
using XamarinTestShared.User;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IAuthHelper authHelper = new AuthHelper();
            ITweetHelper tweetHelper = new TweetHelper();
            IUserHelper userHelper = new UserHelper();

            Console.WriteLine("Start testing");

            authHelper.Authenticate();
            //var tweetJelle = MyClass.publishTweet();

            //MyClass.Retweet(tweetJelle.Id);

            //MyClass.Answer("Hallo Mathisse!" , tweetJelle.Id);

           /* var user = User.GetUserFromScreenName("matdestr");
            if (user == null)
            {
                Console.WriteLine(ExceptionHandler.GetLastException().TwitterDescription);
            }
            var tweets = Timeline.GetUserTimeline(user);
            if (tweets == null)
            {
                Console.WriteLine(ExceptionHandler.GetLastException().TwitterDescription);
            }

             foreach (var tweet in tweets)
             {
                 Console.WriteLine(tweet.Text);
             }*/



       /*     var tweetsHome = MyClass.getHomeLine();
            foreach (var tweet in tweetsHome)
            {
                Console.WriteLine(tweet.Text);
                Console.WriteLine(tweet.CreatedAt);
                Console.WriteLine(tweet.CreatedBy);
                Console.WriteLine(tweet.Id);
                Console.WriteLine(tweet.IsTweetPublished);
                Console.WriteLine(tweet.CreatedBy.ProfileImageUrl);
            }*/


            /*var searchedTweets = tweetHelper.Search("Test search KDG");
            foreach (var searchedTweet in searchedTweets)
            {
                Console.WriteLine(searchedTweet.CreatedBy.Name);
                Console.WriteLine(searchedTweet.Text + "\n");
            }*/

            var users = userHelper.SearchUser("acidshards");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.ScreenName + "\n");
            }
            Console.WriteLine("End testing");
            Console.ReadLine();

        }
    }
}
