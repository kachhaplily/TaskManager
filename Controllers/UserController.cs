using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Dto;
using TaskManager.Model;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<appUser> _userManager;
        private readonly SignInManager<appUser> _signInManager;
        public UserController(UserManager<appUser> userManager, SignInManager<appUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        /// <summary>
        /// method for user registration using user identity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new appUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok(new { Message = "User registered successfully." });
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }
    }
}
