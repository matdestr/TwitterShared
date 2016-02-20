using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinTestShared;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start testing");
            MyClass.Auth();
            var tweetJelle = MyClass.publishTweet();

            //MyClass.Retweet(tweetJelle.Id);

            MyClass.Answer("Hallo Mathisse!" , tweetJelle.Id);



            

            var tweets = MyClass.getHomeLine();
            foreach (var tweet in tweets)
            {
                Console.WriteLine(tweet.Text);
                Console.WriteLine(tweet.CreatedAt);
                Console.WriteLine(tweet.CreatedBy);
                Console.WriteLine(tweet.Id);
                Console.WriteLine(tweet.IsTweetPublished);
            }

            Console.WriteLine("End testing");
            Console.ReadLine();

        }
    }
}
