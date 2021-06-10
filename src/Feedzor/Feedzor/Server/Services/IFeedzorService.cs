using Feedzor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedzor.Server.Services
{
    public interface IFeedzorService
    {

        Task<List<FeedSource>> LoadFeedSources(string email);

        Task<FeedDetailsPageModel> LoadFeedDetails(string feedId);

    }
}
