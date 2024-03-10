using Airline.Data;
using Airline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airline.Controllers
{
    public class UserController : Controller
    {
        private readonly AirlineContext DataBase;
        public UserController(AirlineContext a) 
        {
            this.DataBase = a;
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult flights() 
        {
           
          
            string get_flight_name_from = Request.Form["from"].ToString();
            string get_flight_name_to = Request.Form["to"].ToString();
               
             var flight = get_flight_name_from + " to " + get_flight_name_to;
            var rout = DataBase.Routs.FirstOrDefault(r => r.RoutName == flight);
                if (rout != null)
                {
                    ViewBag.Flight = DataBase.Schedules.Include(r => r.Rout).Include(f => f.FIdNavigation).Where(ro => ro.RoutId == rout.RoutId);
			        return View();
                }
                else
                {
                    ViewBag.error = "Can't Find Flight";
                return View();
                }




           
           
           
        }
        
        public IActionResult Find() 
        {
            
            
            return RedirectToAction(nameof(flights));
        }
	}
}
