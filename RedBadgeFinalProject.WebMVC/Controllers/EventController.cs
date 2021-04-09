using RedBadgeFinalProject.Models.EventModels;
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
            var model = new EventListItem[0];
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
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}