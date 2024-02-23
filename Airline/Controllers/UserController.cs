using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
