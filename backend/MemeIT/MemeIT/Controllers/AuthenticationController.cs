using MemeIT.Helpers.CustomExceptions;
using MemeIT.IServices;
using MemeIT.Models;
using Microsoft.AspNetCore.Mvc;
using InvalidDataException = MemeIT.Helpers.CustomExceptions.InvalidDataException;

namespace MemeIT.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;

        public AuthenticationController(IRegisterService registerService, ILoginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel user)
        {
            try
            {
                await _registerService.RegisterUser(user);
                return Ok($"User {user.Username} successfully added");
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = e.Message });
            }
            catch (Exception e) when (e is InvalidDataException)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [Route("api/login")]
        [HttpGet]
        public async Task<IActionResult> Login(String username, String password)
        {
            try
            {
                String tokenString = await _loginService.Login(username, password);
                return Ok(new { token = tokenString });
            }
            catch (Exception e) when (e is InvalidDataException)
            {
                return Unauthorized(new { error = e.Message });
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}