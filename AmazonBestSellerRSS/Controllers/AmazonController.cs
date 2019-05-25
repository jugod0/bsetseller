using RSSFeed.FeedProvider;
using RSSFeed.Interfaces;
using System.Web.Http;

namespace AmazonBestSellerRSS.Controllers
{
    [RoutePrefix("api/amazon")]
    public class AmazonController : ApiController
    {

        private IAmazonProvider FeedProvider;
        public AmazonController()
        {
            FeedProvider = AmazonProvider.CreateDefaultProvider();
        }

        [Route("electronic")]
        public string GetElectronics()
        {
            return FeedProvider
                .GetElectronics();                
        }

       [Route("book")]
       public string GetBooks()
       {
           return FeedProvider
               .GetBooks();
       }

    }
}