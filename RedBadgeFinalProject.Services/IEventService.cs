using RedBadgeFinalProject.Models.EventModels;
using System.Collections.Generic;

namespace RedBadgeFinalProject.Services
{
    public interface IEventService
    {
        bool CreateEvent(EventCreate model);
        bool DeleteEvent(int eventId);
        EventDetail GetEventById(int id);
        IEnumerable<EventListItem> GetEvents();
        bool UpdateEvent(EventEdit model);
    }
}