using Microsoft.AspNetCore.Mvc;
using WebFrontend.ActionFilters;

namespace WebFrontend.Controllers
{
    [IncludeLayoutData]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
