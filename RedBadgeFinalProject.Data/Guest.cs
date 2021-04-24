using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Data
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter 50 characters or less.")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Please enter 15 characters or less (Yes/No/No Reponse).")]
        public string IsAttending { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Event))]
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }


        //public bool IsAttending { get; set; } // error Unable to cast object of type 'System.Boolean' to type 'System.Array'.
        //Create drop down list?
    }
}
