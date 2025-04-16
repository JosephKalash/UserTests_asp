

using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthController(IUserService UserService, IJwtService JwtService)
    {
        _userService = UserService;
        _jwtService = JwtService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserLoging userLogin)
    {
        var user = _userService.authenticate(userLogin.Username, userLogin.Password);

        if (user != null)
        {
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
        else
        {
            return Unauthorized(new {message = "Invalid username or password"});
        }
    }
}