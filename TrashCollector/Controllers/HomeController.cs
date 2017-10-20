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
            var address = new List<Address>();
            List<Address> addresses = new List<Address>();
            List<Address> zipcode = new List<Address>();
            var username = User.Identity.Name;
            var currentuser = context.Users.Where(m => m.UserName == username).First();
            var possibleusers = context.Users.Where(m => m.PickUpDayID == 5);
            var possibleAddresses = context.Address.Where(m => m.Zipcode != null);
            var invalidPickUps = context.PickUpDay.Where(m => m.day1 <= DateTime.Today && m.day2 >= DateTime.Today).Select(m => m.Id).ToList();
            List<int> invalidAddress = new List<int>();
            foreach (var pickups in invalidPickUps)
            {
               invalidAddress = context.Users.Where(m => m.PickUpDayID == pickups).Select(m => m.AddressID).ToList();
            }
            if (invalidAddress.Count == 0)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                foreach (var place in possibleAddresses)
                {
                 zipcode = db.Address.Where(m => m.Zipcode == currentuser.Workingzipcode).ToList();
                }
                foreach (var place in zipcode)
                {
                    model.City = place.City;
                    model.Street = place.Street;
                    model.Zipcode = place.Zipcode;
                    address.Add(model);
                }
            }
            else
            {
                foreach (var place in invalidAddress)
                {
                    foreach (var checkPlace in possibleAddresses)
                    {
                        addresses = context.Address.Where(m => m.Id != place).ToList();
                    }
                }
                foreach (var thing in addresses)
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
               
            }
            var viewModel = new AddressViewModel();
            {
                viewModel.dropOffs = address;
            };
            return View(viewModel);
        }
       public ActionResult EditZipview()
        {
            return View("WorkingZipcod");
        }
        [HttpPost]

        public ActionResult EditZip(string Workingzipcode)
        {
            var username = User.Identity.Name;
            var currentuser = context.Users.Where(m => m.UserName == username).First();
            currentuser.Workingzipcode = Workingzipcode;
            context.SaveChanges();

            return View("Index");
        }

        public ActionResult WorkdayInfo()
        {
            Address model = new Address();
            List<Address> address = new List<Address>();
            List<Address> addresses = new List<Address>();
            List<Address> zipcode = new List<Address>();
            List<ApplicationUser> todaysPeople = new List<ApplicationUser>();


            var username = User.Identity.Name;
            var currentuser = context.Users.Where(m => m.UserName == username).First();
            var possibleAddresses = context.Address.Where(m => m.Zipcode != null);
            var invalidPickUps = context.PickUpDay.Where(m => m.day1 <= DateTime.Today && m.day2 >= DateTime.Today).Select(m => m.Id).ToList();
            List<int> invalidAddress = new List<int>();
            foreach (var pickups in invalidPickUps)
            {
                invalidAddress = context.Users.Where(m => m.PickUpDayID == pickups).Select(m => m.AddressID).ToList();
            }
            if (invalidAddress.Count == 0)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                foreach (var place in possibleAddresses)
                {
                    zipcode = db.Address.Where(m => m.Zipcode == currentuser.Workingzipcode).ToList();
                }
                foreach (var place in zipcode)
                {
                    todaysPeople = context.Users.Where(m => m.AddressID == place.Id).ToList();
                }
            }
            else
            {
                foreach (var place in invalidAddress)
                {
                    foreach (var checkPlace in possibleAddresses)
                    {
                        addresses = context.Address.Where(m => m.Id != place).ToList();
                    }
                }
                foreach (var thing in addresses)
                {
                    zipcode = context.Address.Where(m => m.Zipcode == currentuser.Workingzipcode).ToList();
                }

                foreach (var place in zipcode)
                {
                    todaysPeople = context.Users.Where(m => m.AddressID == place.Id).ToList();
                }
               
            }
            var viewModel = new UsernameViewModel
            {
                people = todaysPeople
            };
            return View(viewModel);
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