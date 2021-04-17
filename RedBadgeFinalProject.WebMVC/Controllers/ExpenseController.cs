using Microsoft.AspNet.Identity;
using RedBadgeFinalProject.Models.ExpenseModels;
using RedBadgeFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinalProject.WebMVC.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateExpenseService();

            var model = service.GetExpenses();
            
            return View(model);
        }

        public ActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExpense(ExpenseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateExpenseService();

            if (service.CreateExpense(model))
            {
                TempData["SaveResult"] = "Your expense has been created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The expense could not be created.");

            return View(model);
        }

        public ActionResult ExpenseDetails(int id)
        {
            var service = CreateExpenseService();

            var model = service.GetExpenseById(id);

            return View(model);
        }

        public ActionResult EditExpense(int id)
        {
            var service = CreateExpenseService();
            var detail = service.GetExpenseById(id);
            var model =
                new ExpenseEdit
                {
                    ExpenseId = detail.ExpenseId,
                    ExpenseType = detail.ExpenseType,
                    Description = detail.Description,
                    Budget = detail.Budget,
                    ActualAmount = detail.ActualAmount,
                    PaymentMethod = detail.PaymentMethod
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExpense(int id, ExpenseEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.ExpenseId != id)
            {
                ModelState.AddModelError("", "Invalid ID Number");
                return View(model);
            }

            var service = CreateExpenseService();

            if (service.UpdateExpense(model))
            {
                TempData["SaveResult"] = "Your expense was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your expense could not be updated.");
            return View(model);
        }

        [ActionName("DeleteExpense")]
        public ActionResult Delete(int id)
        {
            var service = CreateExpenseService();

            var model = service.GetExpenseById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("DeleteExpense")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExpense(int id)
        {
            var service = CreateExpenseService();

            service.DeleteExpense(id);

            TempData["SaveResult"] = "Your expense has been deleted!";

            return RedirectToAction("Index");
        }


        private ExpenseService CreateExpenseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExpenseService(userId);
            return service;
        }

    }
}