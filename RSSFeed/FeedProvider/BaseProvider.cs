using RSSFeed.Interfaces;

namespace RSSFeed.FeedProvider
{
    public abstract class BaseProvider : IFeedProvider
    {
        public BaseProvider(IRSSFeed rSSFeed,
                            IFeedParser feedParser)
        {
            RSSFeed = rSSFeed;
            Parser = feedParser;
        }

        public IRSSFeed RSSFeed { get; }
        public IFeedParser Parser { get; set; }
    }
}
