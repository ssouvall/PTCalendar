using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.ViewModels
{
    public class PatientDetailsViewModel
    {
        public Patient Patient { get; set; }
        public List<Visit> Visits { get; set; }
        public Visit Visit { get; set; }
    }
}
