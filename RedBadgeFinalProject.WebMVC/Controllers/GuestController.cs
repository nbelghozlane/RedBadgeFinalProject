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
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateGuestService();
            var model = service.GetGuests();
            return View(model);
        }

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
        
        public ActionResult EditGuest(int id)
        {
            var service = CreateGuestService();
            var detail = service.GetGuestById(id);
            var model =
                new GuestEdit
                {
                    GuestId = detail.GuestId,
                    FullName = detail.FullName,
                    Address = detail.Address,
                    PhoneNumber = detail.PhoneNumber,
                    IsAttending = detail.IsAttending
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGuest(int id, GuestEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.GuestId != id)
            {
                ModelState.AddModelError("", "Invalid ID Number");
                return View(model);
            }

            var service = CreateGuestService();

            if (service.UpdateGuest(model))
            {
                TempData["SaveResult"] = "Your guest was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your guest could not be updated.");
            return View(model);
        }

        [ActionName("DeleteGuest")]
        public ActionResult Delete(int id)
        {
            var service = CreateGuestService();

            var model = service.GetGuestById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("DeleteGuest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGuest(int id)
        {
            var service = CreateGuestService();

            service.DeleteGuest(id);

            TempData["SaveResult"] = "Your guest has been deleted!";

            return RedirectToAction("Index");
        }

        private GuestService CreateGuestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GuestService(userId);
            return service;
        }
    }
}