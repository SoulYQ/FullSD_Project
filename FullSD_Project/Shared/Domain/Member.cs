using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullSD_Project.Shared.Domain
{
    public class Member : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name does not meet length requirements")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name does not meet length requirements")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[STFGstfg]\d{7}[A-Za-z]", ErrorMessage = "MemberCardNo does not meet NRIC requirements")] //NRIC Regular Expression
        public string MemberCardNo { get; set; }
        //Address is not a required property, it is intentionally not given any data annotations
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string ContactNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}