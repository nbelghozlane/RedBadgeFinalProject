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
    [Authorize]
    public class EventController : Controller
    {
        //Dependency Injection
        //private string _userId;
        //private readonly IEventService _eventService;

        /*public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }*/
        
        //[Authorize]
        public ActionResult Index()
        {
            //_userId = User.Identity.GetUserId();
            //var userId = User.Identity.GetUserId();
            //Guid.Parse(userId);

            //EventService eventService = new EventService(_userId); //
            var service = CreateEventService();
            
            var model = service.GetEvents();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            //_userId = User.Identity.GetUserId();
            //model.UserId = User.Identity.GetUserId();
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
            //_userId = User.Identity.GetUserId();
            //Guid.Parse(userId);
            var service = CreateEventService();

            var model = service.GetEventById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            //_userId = User.Identity.GetUserId();
            //Guid.Parse(userId);
            var service = CreateEventService();

            var detail = service.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    EventName = detail.EventName,
                    EventType = detail.EventType,
                    Location = detail.Location,
                    EventDateTime = detail.EventDateTime
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            //_userId = User.Identity.GetUserId();
            //Guid.Parse(userId);

            if (!ModelState.IsValid)
                return View(model);

            if(model.EventId != id)
            {
                ModelState.AddModelError("", "Invalid ID Number");
                return View(model);
            }

            var service = CreateEventService();

            //var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateEventService();

            var model = service.GetEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int id)
        {
            //_userId = User.Identity.GetUserId();
            //Guid.Parse(userId);

            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Your event has been deleted!";

            return RedirectToAction("Index");
        }

        private EventService CreateEventService() //Remove for DI
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}
