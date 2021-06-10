using Calendar.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Services.Interfaces
{
    public interface ICalRolesService
    {
        public Task<IEnumerable<string>> ListUserRolesAsync(CalendarUser user);
        public Task<bool> IsUserInRoleAsync(CalendarUser user, string roleName);
        public Task<bool> AddUserToRoleAsync(CalendarUser user, string roleName);
        public Task<bool> RemoveUserFromRoleAsync(CalendarUser user, string roleName);
        public Task<IdentityResult> RemoveUsersFromRolesAsync(CalendarUser user, IEnumerable<string> roles);
        public Task<List<CalendarUser>> UsersNotInRoleAsync(string roleName, int companyId);
        public Task<string> GetRoleNameByIdAsync(string roleId);
    }
}
