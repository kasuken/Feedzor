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
        private UserManager<ApplicationUser> _userManager;

        public FeedzorController(ILogger<FeedzorController> logger, IFeedzorService feedzorService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _feedzorService = feedzorService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedSource>> Get()
        {
            var currentUserName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(currentUserName);

            var result = await _feedzorService.LoadFeedSources(user.Email);

            return result;
        }

        [HttpGet("GetRssById/{feedId}")]
        public async Task<FeedDetailsPageModel> GetById(Guid feedId)
        {
            var result = await _feedzorService.LoadFeedDetails(feedId.ToString());

            return result;
        }

        [HttpPost("AddRss")]
        public async Task AddRss(AddFeed feed)
        {
            var currentUserName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(currentUserName);

            await _feedzorService.AddRss(user.Email, feed.Url);
        }
    }
}
