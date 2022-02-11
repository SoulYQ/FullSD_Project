using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace FullSD_Project.Shared.Domain
{
    public class Brand : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
    }
}
