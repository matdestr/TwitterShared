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
using Tweetinvi;
using XamarinTestShared;
using XamarinTestShared.Authentication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwitterUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       private IAuthHelper authHelper = new AuthHelper();

        public MainPage()
        {
            this.InitializeComponent();
            ExceptionHandler.SwallowWebExceptions = false;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Make CallBack Url!
            authHelper.Authenticate();

            this.Frame.Navigate(typeof(TimelinePage));

        }
    }
}
