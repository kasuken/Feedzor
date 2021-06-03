using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedzor.Shared
{
    public class FeedSource
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Website { get; set; }

        public string Image { get; set; }

        public string LastUpdate { get; set; }

        public List<FeedItem> Items { get; set; }

    }
}
