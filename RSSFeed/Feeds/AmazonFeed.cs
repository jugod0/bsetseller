using RSSFeed.Interfaces;
using RSSFeed.UrlProvider;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
namespace RSSFeed.Feeds
{
    public class AmazonFeed : IRSSFeed
    {
        public AmazonFeed()
        {
            UrlProvider = new AmazonUrlProvider();
        }

        public IUrlProvider UrlProvider { get; }

        public string GetRawFeed(Enum feedType)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(UrlProvider.GetUrl(feedType));
                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.Proxy = null;
                Request.Method = "GET";
                using (WebResponse Response = Request.GetResponse())
                {
                    using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
                    {
                        return Reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return string.Empty;
            }
        }
    }
}
