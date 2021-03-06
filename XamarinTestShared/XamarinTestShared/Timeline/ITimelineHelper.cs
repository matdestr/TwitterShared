﻿using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Core.Interfaces;

namespace XamarinTestShared.Timeline
{
    interface ITimelineHelper
    {
        IEnumerable<ITweet> GetHomeTimeline();

        IEnumerable<IMention> GetMentionsTimeline();
        IEnumerable<ITweet> GetUserTimeline();
        IEnumerable<ITweet> GetUserTimeline(string screenname);
        IEnumerable<ITweet> GetUserTimeline(long id);


    }
}
