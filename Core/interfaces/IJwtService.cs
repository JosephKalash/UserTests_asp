
using UserTests.models;

public interface IJwtService
{
    string GenerateToken(User user);
}