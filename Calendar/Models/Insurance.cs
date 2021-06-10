using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Insurance Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public string PolicyNumber { get; set; }
        public string GroupNumber { get; set; }
        public int Coinsurance { get; set; }
        public int Copay { get; set; }
        public int PatientId { get; set; }

        [DisplayName("Allowed Visits Per Calendar Year")]
        public int MaxVisit { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
