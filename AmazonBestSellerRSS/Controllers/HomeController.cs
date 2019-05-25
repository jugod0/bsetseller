using System.Web.Mvc;

namespace AmazonBestSellerRSS.Controllers
{    
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }
    }
}