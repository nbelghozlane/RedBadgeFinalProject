using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.ExpenseModels
{
    public class ExpenseListItem
    {
        [Display(Name = "Expense ID")]
        public int ExpenseId { get; set; }

        [Display(Name = "Expense Type")]
        public string ExpenseType { get; set; }

        public string Description { get; set; }

        public double Budget { get; set; }

        [Display(Name = "Actual Amount")]
        public double ActualAmount { get; set; }

        [Display(Name = "Event ID")]
        public int? EventId { get; set; }

        public string Event { get; set; }

        [UIHint("IsPurchased")]
        [Display(Name = "Is Purchased")]
        public bool IsPurchased { get; set; }

        //public string UserId { get; set; }

    }
}
