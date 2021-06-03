using Feedzor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedzor.Server.Services
{
    public class FeedzorMockService : IFeedzorService
    {
        public async Task<List<FeedItem>> LoadFeedItems(string feedId)
        {
            var result = new List<FeedItem>();

            for (int i = 0; i < 50; i++)
            {
                result.Add(new FeedItem() { Id = i.ToString(), Title = $"Feed Item {i}", Url = "https://www.bing.com" });
            }

            return result;
        }

        public async Task<List<FeedSource>> LoadFeedSources(string email)
        {
            var result = new List<FeedSource>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(new FeedSource() { Id = Guid.NewGuid(), Title = $"Feed {i}", Url = "https://pisachannel.tv/feed/" });
            }

            return result;
        }
    }
}
