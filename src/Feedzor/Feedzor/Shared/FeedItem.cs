using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedzor.Shared
{
    public class FeedItem
    {

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime Published { get; set; }

        public string Creator { get; set; }

        public string Category { get; set; }

        public string Encoded { get; set; }

    }
}
