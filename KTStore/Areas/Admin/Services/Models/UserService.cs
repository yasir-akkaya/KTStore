using KTStore.Areas.Admin.Services.Interfaces;
using KTStore.Data;
using KTStore.Models;

namespace KTStore.Areas.Admin.Services.Models
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> AddUserAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            var users = _db.ApplicationUser.ToList();
            var roles= _db.Roles.ToList();
            var userRole=_db.UserRoles.ToList();

            foreach (var user in users)
            {
                var roleId = userRole.FirstOrDefault(x => x.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(x => x.Id == roleId).Name;
            }
            return Task.FromResult(users);
        }

        public Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUseryAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
