using SharedCommon.Enums;

namespace RSSFeed.Interfaces
{
    public interface IFeedParser
    {
        IFeedFormatter DefaultFormatter { get; }
        string ParseWithFormat(FormatTypes formatTypes);
        string Parse(string rawFeed);
    }
}
