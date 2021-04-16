using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.ExpenseModels
{
    public class ExpenseDetail
    {
        [Display(Name = "Expense ID")]
        public int ExpenseId { get; set; }

        [Display(Name = "Expense Type")]
        public string ExpenseType { get; set; }

        public string Description { get; set; }

        public double Budget { get; set; }

        [Display(Name = "Actual Amount")]
        public double ActualAmount { get; set; }

        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }
    }
}
