using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.GuestModels
{
    public class GuestCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Is Attending (Yes/No/No Response)")]
        [MaxLength(15, ErrorMessage = "Please enter 15 characters or less (Yes/No/No Reponse).")]
        public string IsAttending { get; set; }
        //public bool? IsAttending { get; set; }

    }
}
