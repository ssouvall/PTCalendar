using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Services.Interfaces
{
    interface ICalCompanyInfoService
    {
        public Task<Company> GetCompanyInfoByIdAsync(int? companyId);

        public Task<List<CalendarUser>> GetAllMembersAsync(int companyId);

        public Task<List<Patient>> GetAllPatientsAsync(int companyId);

        public Task<List<Appointment>> GetAllAppointmentsAsync(int companyId);

        public Task<List<Event>> GetAllEventsAsync(int companyId);

        public Task<List<CalendarUser>> GetMembersInRoleAsync(string roleName, int companyId);

        public Task<bool> AddOfficeManagerAsync(string userId, int companyId);

        public Task RemoveProjectManagerAsync(int companyId);

        public Task<List<CalendarUser>> GetMembersWithoutOMAsync(int companyId);
    }
}
