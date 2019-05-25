using System;

namespace RSSFeed.Interfaces
{
    public interface IRSSFeed
    {
        IUrlProvider UrlProvider { get; }        
        string GetRawFeed(Enum type);
    }
}
