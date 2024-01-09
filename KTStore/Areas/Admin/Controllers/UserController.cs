using KTStore.Areas.Admin.Services.Interfaces;
using KTStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =Other.Role_Admin)]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users= await userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
