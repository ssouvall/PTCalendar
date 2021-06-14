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
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTimeOffset DateOfBirth { get; set; }
        
        [Required]
        [DisplayName("Reason for Visit")]
        public string ReasonForVisit { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }
        [Display(Name = "Work Phone")]
        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }
        [Display(Name = "Cell Phone")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }
        [Display(Name = "Fax Number")]
        [DataType(DataType.PhoneNumber)]
        public string FaxNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AvatarFormFile { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarFileData { get; set; }

        [Display(Name = "File Extension")]
        public string AvatarContentType { get; set; }

        public virtual ICollection<Visit> Visits { get; set; } = new HashSet<Visit>();
        public virtual ICollection<PatientAttachment> Attachments { get; set; } = new HashSet<PatientAttachment>();

    }
}
