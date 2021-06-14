using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{

    public class Event
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Visit Date")]
        public DateTimeOffset Date { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public DateTimeOffset Start { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public DateTimeOffset End { get; set; }

        public virtual ICollection<CalendarUser> Members { get; set; } = new HashSet<CalendarUser>();
        public virtual ICollection<AppointmentComment> Comments { get; set; } = new HashSet<AppointmentComment>();
    }
}
