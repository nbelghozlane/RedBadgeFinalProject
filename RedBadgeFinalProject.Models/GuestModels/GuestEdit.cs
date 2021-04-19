﻿using System;
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
        public string FullName { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(15, ErrorMessage = "Please enter 15 characters or less (Yes/No/No Response).")]
        [Display(Name = "Is Attending (Yes/No/No Response)")]
        public string IsAttending { get; set; }

        //public bool? IsAttending { get; set; }

        [Display(Name = "Event ID")]
        public int? EventId { get; set; }

        public string Event { get; set; }
    }
}
