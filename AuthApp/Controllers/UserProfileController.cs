using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //POST : /api/UserProfile
        public async Task<Object> GetUserProfile() 
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var userRole = await _userManager.GetRolesAsync(user);

            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                Role = userRole
            };
        }


        [HttpGet("ForAdmin")]
        [Authorize(Roles = "Admin")]
        public string ForAdmin() 
        {
            return "for admin only";
        }

        [HttpGet("ForCustomer")]
        [Authorize(Roles = "Customer")]
        public string ForCustomer()
        {
            return "for cusomer only";
        }
    }
}
