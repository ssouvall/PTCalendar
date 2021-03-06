using Calendar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Data
{
    public class ApplicationDbContext : IdentityDbContext<CalendarUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Calendar.Models.AppointmentComment> AppointmentComment { get; set; }
        public DbSet<Calendar.Models.Event> Event { get; set; }
        public DbSet<Calendar.Models.Patient> Patient { get; set; }
        public DbSet<Calendar.Models.PatientAttachment> PatientAttachment { get; set; }
        public DbSet<Calendar.Models.Visit> Visit { get; set; }
    }
}
