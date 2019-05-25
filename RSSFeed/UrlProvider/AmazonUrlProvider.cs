using RSSFeed.Interfaces;
using SharedCommon.Enums;
using SharedCommon.Helpers;
using System;

namespace RSSFeed.UrlProvider
{
    public class AmazonUrlProvider : IUrlProvider        
    {        
        public string BaseUrl => "https://amazon.com";

        public string GetUrl(Enum types)            
        {
            switch(types.ConvertTo<AmazonFeedTypes>())
            {
                case AmazonFeedTypes.EBook:
                    return BaseUrl + "/gp/bestsellers/books/ref=sv_b_2";
                case AmazonFeedTypes.Electronic:
                    return BaseUrl + "/gp/movers-and-shakers/electronics/ref=zg_bsms_nav_b_1_b";
                default:
                    return string.Empty;
            }            
        }
    }
}
