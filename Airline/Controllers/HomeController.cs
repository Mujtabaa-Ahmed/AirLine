using Airline.Data;
using Airline.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace Airline.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirlineContext DataBase;

        public HomeController(AirlineContext DB)
        {
            this.DataBase = DB;
        }
        public IActionResult Login() 
        {
            return View();
        }
        public IActionResult logining(User log) 
        {
            var col = DataBase.Users.FirstOrDefault(x => x.UMail == log.UMail && x.UPass == log.UPass);
            ClaimsIdentity Identity = null;
            bool isAuthenticate = false;
            if (col != null)
            {
                if (col.RId == 1)
                {
                    Identity = new ClaimsIdentity(
                        new[]
                           {
                             new Claim(ClaimTypes.Email , col.UMail),
                             new Claim(ClaimTypes.Role , "Admin")
                           },CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
                if (col.RId == 2)
                {
                    Identity = new ClaimsIdentity(
                        new[] 
                        {
                            new Claim(ClaimTypes.Email , col.UMail),
                            new Claim(ClaimTypes.Role , "User")
                        },CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
                if (isAuthenticate)
                {
                    var principle = new ClaimsPrincipal(Identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                    if (col.RId == 1) //for admin
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else if (true) //for user
                    {
                        return RedirectToAction("Index","User");   
                    }
                }
            }
            ViewBag.data = "Invalid Information";
            return View("Login");
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAdmin()
        {
            return View();
        }
        public IActionResult Users()
        {
            ViewBag.Users = DataBase.Users.Where(s => s.RId == 2).ToList();
            var user = DataBase.Users.Include(x => x.RIdNavigation).ToList();
            return View(user);
        }
        public IActionResult Admins()
        {
            ViewBag.admins = DataBase.Users.Where(a => a.RId == 1).ToList();
            var admin = DataBase.Users.Include(x => x.RIdNavigation).ToList();
            return View(admin);
        }
        public IActionResult addingadmin(User add)
        {
            add.RId = 1;
            DataBase.Add(add);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(AddAdmin));
        }
        public IActionResult AddRole()
        {
            ViewBag.Role = DataBase.Roles.ToList();
            return View();
        }
        public IActionResult addingRole(Role R)
        {
            DataBase.Add(R);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(AddRole));
        }
        public IActionResult flight()
        {
            ViewBag.flight = DataBase.Flights.ToList();
            return View();
        }
        public IActionResult addingflights(Flight F)
        {
            DataBase.Add(F);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(flight));
        }
        public IActionResult FDelete(int? id)
        {
            var del = DataBase.Flights.FirstOrDefault(x => x.FId == id);
            DataBase.Remove(del);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(flight));
        }
        public IActionResult EditingFlight(Flight edF)
        {
            DataBase.Update(edF);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(flight));
        }
        public IActionResult EditFlight(int? id)
        {
            return View(DataBase.Flights.Find(id));
        }
        public IActionResult Route()
        {
            ViewBag.Route = DataBase.Routs.ToList();
            return View();
        }
        public IActionResult addingroute(Rout Rout)
        {
            DataBase.Add(Rout);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(Route));
        }
        public IActionResult RDelete(int? id)
        {
            var del = DataBase.Routs.FirstOrDefault(x => x.RoutId == id);
            DataBase.Remove(del);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(Route));
        }
        public IActionResult EditRoute(int? id)
        {
            var Rid = DataBase.Routs.Find(id);
            return View(Rid);
        }
        public IActionResult EditingRoute(Rout EditedRoute)
        {
            DataBase.Update(EditedRoute);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(Route));
        }
        public IActionResult classes()
        {
            ViewBag.Classes = DataBase.Classes.ToList();
            return View();
        }
        public IActionResult addingclass(Class clas)
        {
            DataBase.Add(clas);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(classes));
        }
        public IActionResult CDelete(int? id)
        {
            var dell = DataBase.Classes.FirstOrDefault(x => x.CId == id);
            DataBase.Remove(dell);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(classes));
        }
        public IActionResult EditClass(int? id)
        {
            return View(DataBase.Classes.Find(id));
        }
        public IActionResult EditingClass(Class EditingClass)
        {
            DataBase.Update(EditingClass);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(classes));
        }
        public IActionResult shedule()
        {
            ViewBag.sch = DataBase.Schedules.ToList();
            var joins = DataBase.Schedules.Include(f => f.FIdNavigation).Include(r => r.Rout).ToList();
            return View(joins);
        }
        public IActionResult sheduleFlight()
        {
            ViewBag.Route = new SelectList(DataBase.Routs, "RoutId", "RoutName");
            ViewBag.Fligt = new SelectList(DataBase.Flights, "FId", "FName");
            return View();
        }
        public IActionResult schedulingFlight(Schedule data)
        {
            DataBase.Add(data);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(sheduleFlight));
        } public IActionResult Sdelete(int? id)
        {
            var sdel = DataBase.Schedules.FirstOrDefault(s => s.SId == id);
            DataBase.Remove(sdel);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(shedule));
        }
        public IActionResult EditSchedule(int? id)
        {
            ViewBag.Route = new SelectList(DataBase.Routs, "RoutId", "RoutName");
            ViewBag.Fligt = new SelectList(DataBase.Flights, "FId", "FName");
            return View(DataBase.Schedules.Find(id));
        }
        public IActionResult EditingSchedule(Schedule editedData) 
        {
            DataBase.Update(editedData);
            DataBase.SaveChanges();
            return RedirectToAction(nameof(shedule));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}