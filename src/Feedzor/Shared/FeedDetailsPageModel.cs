using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedzor.Shared
{
    public class FeedDetailsPageModel
    {
        public FeedSource FeedSource { get; set; }

        public List<FeedItem> Items { get; set; }
    }
}
