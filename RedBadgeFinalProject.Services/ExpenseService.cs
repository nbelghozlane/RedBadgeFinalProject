using RedBadgeFinalProject.Data;
using RedBadgeFinalProject.Models.ExpenseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Services
{
    public class ExpenseService
    {
        private readonly Guid _userId;

        public ExpenseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExpense(ExpenseCreate model)
        {
            var entity =
                new Expense()
                {
                    OwnerId = _userId,
                    ExpenseType = model.ExpenseType,
                    Description = model.Description,
                    Budget = model.Budget,
                    ActualAmount = model.ActualAmount,
                    PaymentMethod = model.PaymentMethod,
                    EventId = model.EventId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Expenses.Add(entity);
                return ctx.SaveChanges() == 1; //error when creating expense
            }
        }

        public IEnumerable<ExpenseListItem> GetExpenses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Expenses
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new ExpenseListItem
                            {
                                ExpenseId = e.ExpenseId,
                                ExpenseType = e.ExpenseType,
                                Description = e.Description,
                                Budget = e.Budget,
                                ActualAmount = e.ActualAmount,
                                EventId = e.EventId,
                                Event = e.Event.EventId + " " + e.Event.EventName
                            }
                        );

                return query.ToArray();

            }
        }

        public ExpenseDetail GetExpenseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Expenses
                        .Single(e => e.ExpenseId == id && e.OwnerId == _userId);
                return
                    new ExpenseDetail
                    {
                        ExpenseId = entity.ExpenseId,
                        ExpenseType = entity.ExpenseType,
                        Description = entity.Description,
                        Budget = entity.Budget,
                        ActualAmount = entity.ActualAmount,
                        PaymentMethod = entity.PaymentMethod,
                        EventId = entity.EventId,
                        Event = entity.Event.EventId + " " + entity.Event.EventName //
                    };
            }
        }

        public bool UpdateExpense (ExpenseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Expenses
                        .Single(e => e.ExpenseId == model.ExpenseId && e.OwnerId == _userId);

                entity.ExpenseType = model.ExpenseType;
                entity.Description = model.Description;
                entity.Budget = model.Budget;
                entity.ActualAmount = model.ActualAmount;
                entity.PaymentMethod = model.PaymentMethod;
                entity.EventId = model.EventId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteExpense(int id)
        {
            using (var ctx =  new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Expenses
                        .Single(e => e.ExpenseId == id && e.OwnerId == _userId);

                ctx.Expenses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
