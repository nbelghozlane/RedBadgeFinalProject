using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.GuestModels
{
    public class GuestEdit
    {
        [Display(Name = "Guest ID")]
        public int GuestId { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Required]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(15, ErrorMessage = "Please enter 15 characters or less (Yes/No/No Response).")]
        [Display(Name = "Is Attending (Yes/No/No Response)")]
        [Required]
        public string IsAttending { get; set; }

        //public bool? IsAttending { get; set; }

        [Display(Name = "Event ID")]
        [Required]
        public int? EventId { get; set; }

        public string Event { get; set; }
    }
}
