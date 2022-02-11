using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSD_Project.Shared.Domain
{
    public class Tool : BaseDomainModel
    {
        [Required]
        public int Year { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]{3}\d{4}[A-Za-z]", ErrorMessage = "security number does not meet requirements")]
        public string securitynumber { get; set; }
        [Required]
        public int? StateId { get; set; }
        public virtual State State { get; set; }
        [Required]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [Required]
        public virtual List<Booking> Bookings { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double RentalRate { get; set; }
    }
}
