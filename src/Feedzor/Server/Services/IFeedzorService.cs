﻿using Feedzor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedzor.Server.Services
{
    public interface IFeedzorService
    {

        Task<List<FeedSource>> LoadFeedSources(string username);

        Task<FeedDetailsPageModel> LoadFeedDetails(string feedId, string username);

        Task MarkAsReadAll(string feedId, string username);

        Task<List<FeedSource>> AddRss(string url, string username);

    }
}
