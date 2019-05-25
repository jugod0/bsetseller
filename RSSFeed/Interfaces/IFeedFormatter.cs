using System;

namespace RSSFeed.Interfaces
{
    public interface IFeedFormatter
    {
        object FormatTo(object obj);        
    }
}
