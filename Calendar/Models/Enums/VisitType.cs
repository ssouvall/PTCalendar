using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.Enums
{
    public enum VisitType
    {
        [Display(Name = "Initial Evaluation")]
        InitialEvaluation,
        [Display(Name = "Follow-Up")]
        FollowUp
    }
}
