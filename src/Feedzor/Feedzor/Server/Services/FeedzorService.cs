using Feedzor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedzor.Server.Services
{
    public class FeedzorService : IFeedzorService
    {
        public Task<List<FeedSource>> AddRss(string email, string url)
        {
            throw new NotImplementedException();
        }

        public Task<FeedDetailsPageModel> LoadFeedDetails(string feedId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FeedSource>> LoadFeedSources(string email)
        {
            throw new NotImplementedException();
        }
    }
}
