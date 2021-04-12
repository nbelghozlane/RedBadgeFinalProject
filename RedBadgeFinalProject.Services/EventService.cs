using RedBadgeFinalProject.Data;
using RedBadgeFinalProject.Models.EventModels;
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
                    EventDate = model.EventDate
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
                                EventDate = e.EventDate
                            }
                        );

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
                        EventDate = entity.EventDate
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
                entity.EventDate = model.EventDate;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
