using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual CalendarUser User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
