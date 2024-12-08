using Microsoft.AspNetCore.Mvc;
using SportAgency.DTOs;
using SportAgency.Entities;
using SportAgency.Services.Interfaces;



namespace SportAgency.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                _userService.RegisterUser(user);
                return Ok(new { Message = "User registered successfully.", Role = user.Role });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                // Извикване на UserService за проверка на потребителя
                var user = await _userService.AuthenticateAsync(loginRequest.Email, loginRequest.Password);

                // Пренасочване според ролята
                switch (user.Role)
                {
                    case "Клуб":
                        return RedirectToAction("ClubDashboard", "Club", new { userId = user.Id });
                    case "Атлет":
                        return RedirectToAction("AthleteDashboard", "Athlete", new { userId = user.Id });
                    default:
                        return Ok(new { Message = "Login successful.", Role = user.Role });
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}