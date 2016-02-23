using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Text;
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
    public sealed partial class NewTweet : Page
    {
        private ITweetHelper tweetHelper = new TweetHelper();
        private string text;
        private ITweet tweet;
        public NewTweet()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                tweet = e.Parameter as ITweet;
            }
            else
            {
            }
        }

        private void NewTweet_TextChanged(object sender, RoutedEventArgs e)
        {
            //CHECKEN ==> gebruik messagedialog
            richEditBox.Document.GetText(TextGetOptions.None, out text);

            if (tweetHelper.GetTweetLength(text) > 140)
            {
                richEditBox.Document.SetText(TextSetOptions.None,"TWITTER BERICHT MAG MAX 140 KARAKTERS BEVATTEN");
            }
        }

        private async void Post_Tweet(object sender, RoutedEventArgs e)
        {
            if (tweet != null)
            {
                var tweetToReply = tweetHelper.PublishReplyTweet(text, tweet.Id);
                await new MessageDialog("Reply ok!").ShowAsync();
                Frame.GoBack();
            }
            else
            {
                var tweetToPublish = tweetHelper.PublishTweet(text);

                var dialog = new MessageDialog("Tweet met tekst: " + tweetToPublish.Text + " is verzonden!");
                await dialog.ShowAsync();
                Frame.GoBack();

            }

        }

        private void GoToHomeAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (TimelinePage));
        }

        private void SearchAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search));
        }

        private void SearchUserAppbarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchUser));
        }
    }
}
