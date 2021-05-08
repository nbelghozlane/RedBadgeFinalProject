using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Please enter 50 characters or less.")]
        public string EventName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string EventType { get; set; } 

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string Location { get; set; }

        [Required]
        public DateTimeOffset EventDateTime { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();

        public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

        public string UserId { get; set; } //

    }
}
