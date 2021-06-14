using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.ViewModels
{
    public class EventDetailsViewModel
    {
        public Event Event { get; set; }
        public Patient Patient { get; set; }
    }
}
