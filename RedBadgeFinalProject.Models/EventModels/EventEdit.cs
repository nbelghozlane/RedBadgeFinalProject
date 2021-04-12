using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.EventModels
{
    public class EventEdit
    {
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string Location { get; set; }

        [Display(Name = "Event Date/Time (Enter in following format: 8/31/2021 4:00 PM)")]
        public DateTimeOffset EventDateTime { get; set; }
    }
}
