using RSSFeed.Formatters;
using RSSFeed.Interfaces;
using SharedCommon.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSSFeed.Factories
{
    public static class FeedFormatterFactory
    {
        public static IFeedFormatter GetFormatter(FormatTypes feedFormat)
        {
            switch(feedFormat)
            {
                
                case FormatTypes.XML:
                case FormatTypes.JSON:                    
                default:
                    return new JSONFormatter();
            }
        }
    }
}
