using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Serves the static index.html file when needed.
    /// This is called on any 404 so that we can get back into our SPA
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }
    }
}
