using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using Tweetinvi.Core.Credentials;

namespace XamarinTestShared.Authentication
{
    public class AuthHelper:IAuthHelper
    {
        private TwitterCredentials appCredentials = new TwitterCredentials("Kfu7pQMNgY1KJIVGiaKuGYsRj", "1URdqiMxNTKBfXp2wnlXbft9iSlhtmGaHyIBBUPwJuKn6ZTMBm");

        public TwitterCredentials GetAppCredentials()
        {
            return appCredentials;
        }

        public string GetUrl()
        {
            var url = CredentialsCreator.GetAuthorizationURL(appCredentials);
            return url;
        }

        public void Authenticate()
        {
            Auth.SetUserCredentials("Kfu7pQMNgY1KJIVGiaKuGYsRj", "1URdqiMxNTKBfXp2wnlXbft9iSlhtmGaHyIBBUPwJuKn6ZTMBm", "1065192774-kvjhsK9EFcgVJ5oEzmJlENrzXTtpZIRku5LAiB4", "WM4WPz0B66BQH0fu6iTsSVRN6FkEoxH6mrXn1GGwF50Yc");
        }
    }
}
