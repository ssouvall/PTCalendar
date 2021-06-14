using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.Enums
{
    public enum EventType
    {
        [Display(Name = "Initial Evaluation")]
        InitialEvaluation,
        [Display(Name = "Follow-Up")]
        FollowUp,
        Meeting
    }
}
