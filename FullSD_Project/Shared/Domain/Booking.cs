using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullSD_Project.Shared.Domain
{
    public class Booking : BaseDomainModel, IValidatableObject
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }
        public DateTime? DateIn { get; set; }
        [Required]
        public int? ToolId { get; set; }
        public virtual Tool Tool { get; set; }
        [Required]
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();

            if (DateIn != null)
            {
                if (DateIn <= DateOut)
                {
                    yield return new ValidationResult("DateIn must be greater than DateOut", new[] { "DateIn" });
                }
            }

        }
    }
}