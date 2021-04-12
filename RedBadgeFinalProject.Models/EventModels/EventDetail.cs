using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.EventModels
{
    public class EventDetail
    {
        [Display(Name = "Event ID")]
        public int EventId { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        public string Location { get; set; }

        [Display(Name = "Event Date & Time")]
        public DateTimeOffset EventDateTime { get; set; }
    }
}
