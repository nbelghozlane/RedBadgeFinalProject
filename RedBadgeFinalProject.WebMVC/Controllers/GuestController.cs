using Microsoft.AspNet.Identity;
using RedBadgeFinalProject.Models.GuestModels;
using RedBadgeFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinalProject.WebMVC.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateGuestService();
            var model = service.GetGuests();
            return View(model);
        }

        //Get
        public ActionResult CreateGuest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGuest(GuestCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGuestService();

            if (service.CreateGuest(model))
            {
                TempData["SaveResult"] = "Your guest has been created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The guest could not be created.");

            return View(model);
        }

        public ActionResult GuestDetails(int id)
        {
            var service = CreateGuestService();

            var model = service.GetGuestById(id);

            return View(model);
        }

        private GuestService CreateGuestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GuestService(userId);
            return service;
        }
    }
}