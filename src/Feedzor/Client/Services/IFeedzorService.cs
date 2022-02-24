using Feedzor.Shared;
using System.Threading.Tasks;

namespace Feedzor.Client.Services
{
    public interface IFeedzorService
    {

        Task<FeedDetailsPageModel> GetRssById(string id);

    }
}
