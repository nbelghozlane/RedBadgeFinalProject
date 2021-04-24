using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Models.ExpenseModels
{
    public class ExpenseEdit
    {
        [Display(Name = "Expense ID")]
        public int ExpenseId { get; set; }

        [Display(Name = "Expense Type (Ex: Food, Equipment Rental, etc.)")]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        [Required]
        public string ExpenseType { get; set; }

        [MaxLength(100, ErrorMessage = "Please enter 100 characters or less.")]
        [Required]
        public string Description { get; set; }

        public double Budget { get; set; }

        [Display(Name = "Actual Amount")]
        public double ActualAmount { get; set; }

        [Display(Name = "Payment Method")]
        [MaxLength(12, ErrorMessage = "Please enter 12 characters or less.")]
        public string PaymentMethod { get; set; }

        public string Event { get; set; }

        [Display(Name = "Event ID")]
        [Required]
        public int? EventId { get; set; }
    }
}
