using KTStore.Models;

namespace KTStore.Areas.Admin.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> AddUserAsync(ApplicationUser user);
        public Task<List<ApplicationUser>> GetAllUsersAsync();
        public Task<ApplicationUser> GetUserByIdAsync(int id);
        public Task<bool> UpdateUseryAsync(ApplicationUser user);
        public Task<bool> DeleteUserAsync(int id);
    }
}
