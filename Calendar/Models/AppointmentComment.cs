using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class AppointmentComment
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("User Comment")]
        public string Comment { get; set; }

        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Appointment")]
        public int AppointmentId { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual CalendarUser User { get; set; }
    }
}
