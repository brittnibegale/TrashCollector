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
            var addresses = context.Address.Where(m => m.Zipcode == currentuser.Workingzipcode).ToList();
            
            foreach(var place in addresses)
            {
                model.City = place.City;
                model.Street = place.Street;
                model.Zipcode = place.Zipcode;
                addresses.Add(model);
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