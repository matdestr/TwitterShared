using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Tweetinvi.Core.Interfaces;
using XamarinTestShared.User;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitterUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchUser : Page
    {
        private IUserHelper userHelper = new UserHelper();
        private IEnumerable<IUser> searchedUsers;
        private bool isFollowed;
        public SearchUser()
        {
            this.InitializeComponent();
        }

        private void GoToHomeAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (TimelinePage));
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            AutoSuggestBox.Text = "";
            SearchUserResultTweets.Items?.Clear();
        }

        private void SearchAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (Search));
        }

        private void NewTweetAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (NewTweet));
        }

        private async void BlockButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
            {
                IUser user = frameworkElement.DataContext as IUser;
                if (user != null)
                {
                    userHelper.BlockUser(user.Id);
                    await new MessageDialog("User blocked!").ShowAsync();
                }
            }
            else
            {
                await new MessageDialog("Error!").ShowAsync();

            }
        }

        private async void FollowButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
            {
                IUser user = frameworkElement.DataContext as IUser;
                if (user != null)
                {
                    isFollowed = userHelper.FollowUser(user.Id);
                    if (!isFollowed)
                    {
                        await new MessageDialog("User already followed!").ShowAsync();

                    }
                    else
                    {
                        await new MessageDialog("User followed!").ShowAsync();
                    }
                }
            }
            else
            {
                await new MessageDialog("Error!").ShowAsync();

            }
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            searchedUsers = userHelper.SearchUser(args.QueryText);
            foreach (var user in searchedUsers) 
            {
                SearchUserResultTweets.Items?.Add(user);

            }
        }

        private void UIElement_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void SearchUserResultTweets_OnItemClick(object sender, ItemClickEventArgs e)
        {
            IUser userClicked = e.ClickedItem as IUser;
            this.Frame.Navigate(typeof (Profile), userClicked);
        }
    }
}
