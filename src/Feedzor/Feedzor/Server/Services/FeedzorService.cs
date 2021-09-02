using Feedzor.Server.Data;
using Feedzor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Feedzor.Server.Services
{
    public class FeedzorService : IFeedzorService
    {
        ApplicationDbContext _applicationDbContext;

        public FeedzorService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<FeedSource>> AddRss(string url, string username)
        {
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            _applicationDbContext.FeedSources.Add(new FeedSource() { Title = feed.Title.Text, UserName = username, Url = url });
            await _applicationDbContext.SaveChangesAsync();

            return _applicationDbContext.FeedSources.Where(u => u.UserName == username).ToList();
        }

        public async Task MarkAsReadAll(string feedId, string username)
        {
            var source = _applicationDbContext.FeedSources.Where(s => s.Id == Guid.Parse(feedId)).FirstOrDefault();

            using var reader = XmlReader.Create(source.Url);
            var feed = SyndicationFeed.Load(reader);

            foreach (var item in feed.Items)
			{
                _applicationDbContext.FeedItemReadUsers.Add(new FeedItemReadUser() { ItemId = item.Id, UserName = username});
            }

            _applicationDbContext.SaveChanges();
        }

        public async Task<FeedDetailsPageModel> LoadFeedDetails(string feedId, string username)
        {
            var model = new FeedDetailsPageModel();
            model.Items = new List<FeedItem>();

            var source = _applicationDbContext.FeedSources.Where(s => s.Id == Guid.Parse(feedId)).FirstOrDefault();
            var readItems = _applicationDbContext.FeedItemReadUsers.Where(u => u.UserName == username).ToList();

            model.FeedSource = source;

            using var reader = XmlReader.Create(source.Url);
            var feed = SyndicationFeed.Load(reader);

            foreach (var item in feed.Items)
            {
                if (readItems.FirstOrDefault(i => i.ItemId == item.Id && i.UserName == username) == null)
				{
                    var newItem = new FeedItem() { Id = item.Id, Title = item.Title.Text, Description = item.Summary?.Text };

                    model.Items.Add(newItem);
                }
            }

            return model;
        }

        public async Task<List<FeedSource>> LoadFeedSources(string username)
        {
            return _applicationDbContext.FeedSources.Where(u => u.UserName == username).ToList();
        }
    }
}
