using Microsoft.AspNet.Identity;
using RedBadgeFinalProject.Models.EventModels;
using RedBadgeFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinalProject.WebMVC.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        [Authorize]
        public ActionResult Index()
        {
            /*var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);*/

            var service = CreateEventService(); //

            var model = service.GetEvents();

            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your event has been created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The event could not be created.");
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateEventService();

            var model = service.GetEventById(id);

            return View(model);
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}