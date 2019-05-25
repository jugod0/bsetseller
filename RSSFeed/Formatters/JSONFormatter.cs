
using Newtonsoft.Json;
using RSSFeed.Interfaces;

namespace RSSFeed.Formatters
{
    public class JSONFormatter : IFeedFormatter
    {
        public object FormatTo(object obj)
        {
            return JsonConvert.SerializeObject(obj);            
        }
    }
}
