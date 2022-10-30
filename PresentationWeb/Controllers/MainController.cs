using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PresentationWeb.Controllers
{
   // [Authorize]
    [Route("")]
    [Route("Main")]
    public class MainController : Controller
    {
        
        [HttpGet]
        [Route("")]
        [Route("Home2")]
        public ActionResult Home2()
        {
            return View();
        }


      

    }
}
