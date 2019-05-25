
using System;

namespace RSSFeed.Interfaces
{
    public interface IUrlProvider
    {
        string BaseUrl { get; }
        string GetUrl(Enum type);
    }
}
