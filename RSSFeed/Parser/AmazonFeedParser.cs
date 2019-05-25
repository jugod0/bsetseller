using Newtonsoft.Json;
using RSSFeed.Factories;
using RSSFeed.Interfaces;
using SharedCommon.Enums;
using SharedCommon.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSSFeed.Parser
{
    public class AmazonFeedParser : IFeedParser
    {
        private const string HTML_UL_ID = "zg-ordered-list";
        private const string BaseURL = "http://amazon.com/";

        public AmazonFeedParser()
        {
            DefaultFormatter = FeedFormatterFactory.GetFormatter(FormatTypes.JSON);
        }
        public IFeedFormatter DefaultFormatter { get; }

        public string Parse(string rawFeed)
        {
            var extractedRawList = GetItemListFromRawFeed(rawFeed);
            var parsedObject = ParseIntoObject(extractedRawList);
            var formatted = (string)DefaultFormatter.FormatTo(parsedObject);
            return formatted;
        }

        protected object ParseIntoObject(string extractedRawList)
        {
            var regexMatches = new Regex(@"(?<=<li.*>)((\n|.)*?)(?=<\/li>)", RegexOptions.Compiled);
            return regexMatches.Matches(extractedRawList)
                    .Cast<Match>()
                    .Select(m => new Item
                    {
                        Title = GetTitle(m.Value),
                        Description = GetDescription(m.Value),
                        Link = BaseURL + GetLink(m.Value),
                        ImageUrl = GetImageUrl(m.Value)
                    })
                    .ToList();            
        }

        protected string GetImageUrl(string value)
        {
            var pattern = "(?<=<img(.*)src=\")(.*)g(?=\")";
            return Regex.Match(value, pattern).Value;
        }

        protected string GetLink(string value)
        {
            var pattern = "(?<=<a(.*)href=\")(.*)(?=\">(.*)zg-text)";
            return Regex.Match(value, pattern).Value;
        }

        protected string GetTitle(string value)
        {
            var pattern = "(?<=<div(\n|\r\n|.)*(data-rows=){1}(.*)>)(\\s|\n|.)*?(?=(\r\n</div>|\n</div>|</div>))";
            return Regex.Match(value, pattern).Value;
        }

        protected string GetDescription(string value)
        {
            var pattern = "(?<=<a(.*)(title=\"){1})(.*?)(?=\")";
            return Regex.Match(value, pattern).Value;
        }

        protected string GetItemListFromRawFeed(string rawFeed)
        {
            var regexPatter = "<ol\\s+id=[\"|\']" + HTML_UL_ID +"[\"|\'](\n |\r\n |.)*</ol>";
            var match = Regex.Match(rawFeed, regexPatter).Value;            
            return match;
        }

        public string ParseWithFormat(FormatTypes formatType)
        {
            var formatter = FeedFormatterFactory.GetFormatter(formatType);
            throw new System.NotImplementedException();
        }
    }
}
