// Services/JwtService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UserTests.models;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        // Get JWT settings from configuration
        var jwtKey = _configuration["Jwt:Key"];
        var jwtIssuer = _configuration["Jwt:Issuer"];
        var jwtAudience = _configuration["Jwt:Audience"];
        var jwtDurationMinutes = int.Parse(_configuration["Jwt:DurationInMinutes"]);

        // Create security key
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        // Create credentials
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Set claims - you can add more custom claims based on user
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("id", user.Id.ToString()),
            new Claim("Role", user.IsAdmin ? "Admin" : "User")
        };

        // Create token
        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtDurationMinutes),
            signingCredentials: credentials
        );

        // Return serialized token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}