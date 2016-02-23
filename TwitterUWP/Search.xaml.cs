﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tweetinvi.Core.Interfaces;
using XamarinTestShared.Tweet;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitterUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        private ITweetHelper tweetHelper = new TweetHelper();
        private IEnumerable<ITweet> searchedTweets;

        public Search()
        {
            this.InitializeComponent();
            
        }

        private void UIElement_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void RetweetButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FavouriteButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ReplyButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ITweet> GetSearchResults()
        {
            return searchedTweets;
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            AutoSuggestBox.Text = "";
            SearchResultTweets.Items?.Clear();
        }

        private void NewTweetAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (NewTweet));
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            searchedTweets = tweetHelper.Search(args.QueryText);
            foreach (var searchedTweet in searchedTweets)
            {
                SearchResultTweets.Items?.Add(searchedTweet);

            }
        }

        private void GoToHomeAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (TimelinePage));
        }
    }
}
