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
            Auth.SetUserCredentials("pO4Xfz3U9cUaa15uqrba5gFZw", "9gantlmXO546lcJNnsI81irKXpOl4pKhtmpp9pdDIQTwfGMVLJ",
                "1065192774-Lrawu7eFSD4ClcKgZwZEJhpqhTnPWZzJYMPuI2K", "BpxK05JZF1LX7QYrfLXjA3N7TjoJp6IH1Oc7h7W1O9hec");
            //Auth.SetUserCredentials("Kfu7pQMNgY1KJIVGiaKuGYsRj", "1URdqiMxNTKBfXp2wnlXbft9iSlhtmGaHyIBBUPwJuKn6ZTMBm", "1065192774-kvjhsK9EFcgVJ5oEzmJlENrzXTtpZIRku5LAiB4", "WM4WPz0B66BQH0fu6iTsSVRN6FkEoxH6mrXn1GGwF50Yc");
        }
    }
}
