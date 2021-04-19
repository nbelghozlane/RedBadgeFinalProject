using RedBadgeFinalProject.Data;
using RedBadgeFinalProject.Models.EventModels;
using RedBadgeFinalProject.Models.ExpenseModels;
using RedBadgeFinalProject.Models.GuestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    OwnerId = _userId,
                    EventName = model.EventName,
                    EventType = model.EventType,
                    Location = model.Location,
                    EventDateTime = model.EventDateTime
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new EventListItem
                            {
                                EventId = e.EventId,
                                EventName = e.EventName,
                                EventType = e.EventType,
                                EventDateTime = e.EventDateTime,

                                Guests = e.Guests  //
                                    .Select(
                                    g => new GuestListItem
                                    {
                                        GuestId = g.GuestId,
                                        FullName = g.FullName

                                    }).ToList(),

                                Expenses = e.Expenses  //
                                    .Select(
                                    exp => new ExpenseListItem
                                    {
                                        ExpenseId = exp.ExpenseId,
                                        Description = exp.Description

                                    }).ToList()

                            });
                           
                return query.ToArray();

            }
        }

        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == id && e.OwnerId == _userId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        EventName = entity.EventName,
                        EventType = entity.EventType,
                        Location = entity.Location,
                        EventDateTime = entity.EventDateTime
                    };
            }

        }

        public bool UpdateEvent (EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.EventName = model.EventName;
                entity.EventType = model.EventType;
                entity.Location = model.Location;
                entity.EventDateTime = model.EventDateTime;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == eventId && e.OwnerId == _userId);

                ctx.Events.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
