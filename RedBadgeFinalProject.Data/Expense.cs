using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Data
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string ExpenseType { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Please enter 100 characters or less.")]
        public string Description { get; set; }

        public double Budget { get; set; }

        public double ActualAmount { get; set; }

        [MaxLength(12, ErrorMessage = "Please enter 12 characters or less.")]
        public string PaymentMethod { get; set; }

        [DefaultValue(false)]
        public bool IsPurchased { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Event))] 
        public int? EventId { get; set; } 
        public virtual Event Event { get; set; }
        
    }
}
