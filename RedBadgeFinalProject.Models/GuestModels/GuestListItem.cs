﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.GuestModels
{
    public class GuestListItem
    {
        [Display(Name = "Guest ID")]
        public int GuestId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Is Attending")]
        public bool IsAttending { get; set; }

        //Add in public int AdditionalNumberOfGuests??
    }
}