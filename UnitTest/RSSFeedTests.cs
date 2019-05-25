using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RSSFeed.Feeds;
using RSSFeed.Parser;
using RSSFeed.UrlProvider;
using SharedCommon.Enums;
using SharedCommon.Models;

namespace UnitTest
{
    [TestClass]
    public class RSSFeedTests
    {
        [TestMethod]
        public void gets_correc_url()
        {
            var urlprovider = new AmazonUrlProvider();

            var result = urlprovider.GetUrl(AmazonFeedTypes.EBook);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void works_rss_feed_link()
        {
            var feed = new AmazonFeed();

            var result = feed.GetRawFeed(AmazonFeedTypes.EBook);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void parser_grabs_correct_regex_works_rss_feed_link()
        {
            var feed = new AmazonFeed();
            var parser = new AmazonFeedParser();

            var result = feed.GetRawFeed(AmazonFeedTypes.EBook);
            var parsed = parser.Parse(result);
            Assert.IsTrue(!string.IsNullOrEmpty(parsed));
        }

        [TestMethod]
        public void jsonparsetest()
        {
            var item = new Item()
            {
                Description = "desc",
                ImageUrl = "url",
                Link = "kku",
                Title = "titl"
            } as object;

            var test = JsonConvert.SerializeObject(item);
            Assert.IsTrue(!string.IsNullOrEmpty(test));
        }
    }
}
