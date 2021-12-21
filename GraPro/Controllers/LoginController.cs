using Microsoft.AspNetCore.Mvc;

namespace GraPro.Dal
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
