using Microsoft.AspNet.Identity;
using RedBadgeFinalProject.Models.ExpenseModels;
using RedBadgeFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedBadgeFinalProject.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Expense")]
    public class ExpenseController : ApiController
    {
        private bool SetCheckmarkState(int expenseId, bool newState)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExpenseService(userId);
            var detail = service.GetExpenseById(expenseId);

            var updatedExpense =
                new ExpenseEdit
                {
                    ExpenseId = detail.ExpenseId,
                    ExpenseType = detail.ExpenseType,
                    Description = detail.Description,
                    Budget = detail.Budget,
                    ActualAmount = detail.ActualAmount,
                    PaymentMethod = detail.PaymentMethod,
                    Event = detail.Event,
                    EventId = detail.EventId,
                    IsPurchased = newState
                };

            return service.UpdateExpense(updatedExpense);
        }

        [Route("{id}/IsPurchased")]
        [HttpPut]
        public bool ToggleCheckmarkOn(int id) => SetCheckmarkState(id, true);

        [Route("{id}/IsPurchased")]
        [HttpDelete]
        public bool ToggleCheckmarkOff(int id) => SetCheckmarkState(id, false);
    }
}

