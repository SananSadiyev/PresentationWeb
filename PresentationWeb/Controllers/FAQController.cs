using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWeb.Controllers
{
    public class FAQController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("FAQ")]
        public IActionResult FAQ()
        {
            return View();
        }
    }
}
