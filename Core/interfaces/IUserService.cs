
using UserTests.models;

public interface IUserService
{
    User? authenticate(string Username, string Password);
    Task<User> register(UserRegister userRegister);

}