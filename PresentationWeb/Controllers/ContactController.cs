using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWeb.Controllers
{
    public class ContactController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
