namespace RSSFeed.Interfaces
{
    internal interface IFeedProvider
    {        
        IRSSFeed RSSFeed { get; }        
        IFeedParser Parser { get; set; }
    }
}
