using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.EventModels
{
    public class EventListItem
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; } 
        public DateTime EventDate { get; set; }
    }
}
