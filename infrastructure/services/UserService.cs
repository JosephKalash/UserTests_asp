

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using UserTests.models;

public interface IUserService
{
    User? authenticate(string Username, string Password);
    Task<User> register(UserRegister userRegister);

}

public class UserService : IUserService
{
    public UserService(TestDbContext context)
    {
        _context = context;
    }

    private readonly PasswordHasher<User> _passwordHasher = new();
    private readonly TestDbContext _context;

    public async Task<User> register(UserRegister userRegister)
    {
        var user = new User { Username = userRegister.Username , IsAdmin = userRegister.IsAdmin};
        var hashedPassowrd = _passwordHasher.HashPassword(user, userRegister.Password);
        user.PasswordHash = hashedPassowrd;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    User? IUserService.authenticate(string Username, string Password)
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == Username);
        if (user == null) return null;
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, Password);
        return result == PasswordVerificationResult.Success ? user : null;

    }

}