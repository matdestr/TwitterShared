using System;
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
using XamarinTestShared.Timeline;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitterUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private ITimelineHelper timelineHelper = new TimelineHelper();
        public HomePage()
        {
            this.InitializeComponent();
            var tweets = timelineHelper.GetHomeTimeline();
            foreach (var tweet in tweets)
            {
                TimeLineTweets.Items?.Add(tweet);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void NewTweetAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (NewTweet));
        }

        private void SearchAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (Search));
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
