using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Services.Interfaces
{
    interface ICalPatientService
    {
        public Task<bool> IsUserAssignedToPatient (string userId, int patientId);

        public Task<bool> AddUserToPatientAsync(string userId, int patientId);

        public Task RemoveUserFromPatientAsync(string userId, int patientId);

        public Task<List<Patient>> ListUserPatientsAsync(string userId);

        public Task<List<Patient>> GetAllPatientsByCompany(int companyId);

        public Task<List<Patient>> GetDischargedPatientsByCompany(int companyId);

        public Task<List<Patient>> GetActivePatientsByCompany(int companyId);
    }
}
