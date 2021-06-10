using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("ICD-10 Code")]
        public string Code { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
