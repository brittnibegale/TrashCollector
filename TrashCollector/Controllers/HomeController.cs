using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Map()
        {
            Address model = new Address();
            List<Address> address = new List<Address>();
            var username = User.Identity.Name;
            var currentuser = context.Users.Where(m => m.UserName == username).First();
            var invalidPickUps = context.PickUpDay.Where(m => m.day1 <= DateTime.Today && m.day2 >= DateTime.Today).Select(m => m.Id).ToList();
            List<int> invalidAddress = new List<int>();
            foreach (var pickups in invalidPickUps)
            {
               invalidAddress = context.Users.Where(m => m.PickUpDayID == pickups).Select(m => m.AddressID).ToList();
            }
            List<Address> addresses = new List<Address>();
            foreach (var place in invalidAddress)
            {
                addresses = context.Address.Where(m => m.Id != place).ToList();
            }
            List<Address> zipcode = new List<Address>();
            foreach(var thing in addresses)
            {
                zipcode = context.Address.Where(m => m.Zipcode == currentuser.Workingzipcode).ToList();
            }

            foreach (var place in zipcode)
            {
                model.City = place.City;
                model.Street = place.Street;
                model.Zipcode = place.Zipcode;
                address.Add(model);
            }

            return View(address);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}