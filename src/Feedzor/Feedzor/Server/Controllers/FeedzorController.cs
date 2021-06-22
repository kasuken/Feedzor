using Feedzor.Server.Models;
using Feedzor.Server.Services;
using Feedzor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Feedzor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FeedzorController : ControllerBase
    {
        private readonly ILogger<FeedzorController> _logger;
        private readonly IFeedzorService _feedzorService;

        public FeedzorController(ILogger<FeedzorController> logger, IFeedzorService feedzorService)
        {
            _logger = logger;
            _feedzorService = feedzorService;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedSource>> Get()
        {
            var currentUser = User.Identity?.Name;

            var result = await _feedzorService.LoadFeedSources(currentUser);

            return result;
        }

        [HttpGet("GetRssById/{feedId}")]
        public async Task<FeedDetailsPageModel> GetById(Guid feedId)
        {
            await Task.Delay(2000);
            var result = await _feedzorService.LoadFeedDetails(feedId.ToString());

            return result;
        }

        [HttpPost("AddRss")]
        public async Task AddRss(AddFeed feed)
        {
            var currentUser = User.Identity?.Name;

            await _feedzorService.AddRss(feed.Url, currentUser);
        }
    }
}
