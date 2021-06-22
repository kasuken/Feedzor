using Feedzor.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedzor.Server.Services
{
    public class FeedzorMockService : IFeedzorService
    {
        public Task<List<FeedSource>> AddRss(string url, string username)
        {
            throw new NotImplementedException();
        }

        public async Task<FeedDetailsPageModel> LoadFeedDetails(string feedId)
        {
            var items = new List<FeedItem>();

            for (int i = 0; i < 50; i++)
            {
                items.Add(new FeedItem() { Id = i.ToString(), Title = $"Feed Item {i}", Url = "https://www.bing.com" });
            }

            var pageModel = new FeedDetailsPageModel();
            pageModel.Items = new List<FeedItem>();
            pageModel.FeedSource = new FeedSource();

            pageModel.Items = items;
            pageModel.FeedSource = new FeedSource() { Id = Guid.NewGuid(), Title = $"Feed Title", Url = "https://pisachannel.tv/feed/" };

            return pageModel;
        }

        public async Task<List<FeedSource>> LoadFeedSources(string username)
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
