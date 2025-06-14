using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTests.models;

namespace UserTests.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(TestDbContext context, IUserService userService) : ControllerBase
{
    private readonly TestDbContext _context = context;
    private readonly IUserService _userService = userService;

    [HttpGet()]
    [Authorize(Policy = AdminPolicy.PolicyName)]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }
    [HttpPost()]
    [Authorize(Policy = AdminPolicy.PolicyName)]
    public async Task<ActionResult<User>> AddUser([FromBody] UserRegister user)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(x => x.Key, x => x.Value?.Errors.Select(e => e.ErrorMessage).ToList());

        }
        var user_ = await _userService.register(user);
        return Ok(user_);
    }
    [HttpGet("me")]
    public async Task<ActionResult<User>> GetMe()
    {
        var userId = User.FindFirstValue("id");
        if (userId == null) return Unauthorized();

        var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
        return Ok(user);
    }
}
