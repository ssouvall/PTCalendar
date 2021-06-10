using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        
        [Display(Name = "Visit Type")]
        public string VisitType { get; set; }

        [Display(Name = "Visit Date")]
        public DateTimeOffset Date { get; set; }

        [Display(Name = "Start Time")]
        public DateTimeOffset Start { get; set; }

        [Display(Name = "End Time")]
        public DateTimeOffset End { get; set; }

        [Display(Name = "Treating Therapist")]
        public CalendarUser TreatingTherapist { get; set; }

        [Required]
        public string Subjective { get; set; }

        [Required]
        public string Objective { get; set; }

        [Required]
        public string Assessment { get; set; }
        
        [Required]
        public string Plan { get; set; }

    }
}
