using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Core.Credentials;

namespace XamarinTestShared.Authentication
{
    interface IAuthHelper
    {
        TwitterCredentials GetAppCredentials();
        string GetUrl();

        void Authenticate();
    }
}
