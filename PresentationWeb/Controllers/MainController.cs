using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWeb.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public ActionResult Home()
        {
            return View();
        }

    }
}
