using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [DisplayName("Patient")]
        public int PatientId { get; set; }

        [DisplayName("Subject")]
        public string Title { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [Required]
        [DisplayName("Recipient")]
        public string RecipientId { get; set; }

        [Required]
        [DisplayName("Sender")]
        public string SenderId { get; set; }

        [DisplayName("Has been viewed")]
        public bool Viewed { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual CalendarUser Recipient { get; set; }
        public virtual CalendarUser Sender { get; set; }
    }
}
