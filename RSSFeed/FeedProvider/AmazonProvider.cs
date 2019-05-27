using RSSFeed.Feeds;
using RSSFeed.Interfaces;
using RSSFeed.Parser;
using SharedCommon.Enums;

namespace RSSFeed.FeedProvider
{
    public class AmazonProvider : BaseProvider, IAmazonProvider
    {
        private AmazonProvider(IRSSFeed rSSFeed,
                              IFeedParser feedParser)            
            :base(rSSFeed, feedParser)
        {            
        }


        public static AmazonProvider CreateDefaultProvider()
        {
            return new AmazonProvider(new AmazonFeed(),
                                      new AmazonFeedParser());
        }

        public string GetBooks()
        {
            return Parser
                    .Parse(RSSFeed
                    .GetRawFeed(AmazonFeedTypes.EBook));
        }

        public string GetElectronics()
        {
            return Parser
                    .Parse(RSSFeed
                    .GetRawFeed(AmazonFeedTypes.Electronic));
        }
    }
}
