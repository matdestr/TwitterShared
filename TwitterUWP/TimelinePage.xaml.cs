using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models.Entities;
using XamarinTestShared.Timeline;
using XamarinTestShared.Tweet;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitterUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimelinePage : Page
    {
        private ITimelineHelper timelineHelper = new TimelineHelper();
        private ITweetHelper tweetHelper = new TweetHelper();
        public TimelinePage()
        {
            this.InitializeComponent();
            GetTweets();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            TimeLineTweets.Items?.Clear();
            GetTweets();
        }

        private void NewTweetAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (NewTweet));
        }

        private void SearchAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (Search));
        }

        private void UIElement_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private async void RetweetButton_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
            {
                ITweet tweet = frameworkElement.DataContext as ITweet;
                if (tweet != null)
                {
                    tweetHelper.Retweet(tweet.Id);
                    await new MessageDialog("Tweet is geretweet!").ShowAsync();
                }
            }
            else
            {
                await new MessageDialog("Error!").ShowAsync();

            }
        }

        private async void FavouriteButton_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
            {
                ITweet tweet = frameworkElement.DataContext as ITweet;
                if (tweet != null)
                {
                    tweetHelper.FavouriteTweet(tweet.Id);
                    await new MessageDialog("Tweet is favourited!").ShowAsync();
                }
            }
            else
            {
                await new MessageDialog("Error!").ShowAsync();

            }
        }

        private async void ReplyButton_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
            {
                ITweet tweet = frameworkElement.DataContext as ITweet;
                if (tweet != null)
                {
                    this.Frame.Navigate(typeof (NewTweet), tweet);
                    //await new MessageDialog("Reply Ok!").ShowAsync();
                }
            }
            else
            {
                await new MessageDialog("Error!").ShowAsync();

            }
        }

        private void GetTweets()
        {
            var tweets = timelineHelper.GetHomeTimeline();

            foreach (var tweet in tweets)
            {

                TimeLineTweets.Items?.Add(tweet);
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
            {
                ITweet tweet = frameworkElement.DataContext as ITweet;
                if (tweet != null)
                {
                    if (tweet.CreatedBy.ScreenName == User.GetLoggedUser().ScreenName)
                    {
                        var success = tweetHelper.DeleteTweet(tweet.Id);
                        TimeLineTweets.Items?.Clear();
                        GetTweets();
                    }
                    else
                    {
                        await new MessageDialog("U bent niet de eigenaar!").ShowAsync();

                    }

                }
            }
            else
            {
                await new MessageDialog("Error!").ShowAsync();

            }
        }
    }
}
