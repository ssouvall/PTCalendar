using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        [DisplayName("File Extension")]
        public string FileContentType { get; set; }

        //add new HashSet because if it returns null  you will get an object reference error, but new HashSet makes it so this doesn't break the code if the count is 0
        public virtual ICollection<CalendarUser> Members { get; set; } = new HashSet<CalendarUser>();
        public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public virtual ICollection<Invite> Invites { get; set; } = new HashSet<Invite>();
    }
}
