

public interface IUserService
{
    User authenticate(string Username, string Password);

}

public class UserService : IUserService
{
    private List<User> _users = new List<User>{
        new User { Id = 1, Username = "Joseph", Password = "1234"},
        new User { Id = 2, Username = "Yazan", Password = "1234"}
    };
    User IUserService.authenticate(string Username, string Password)
    {
        return _users.FirstOrDefault(x => x.Username == Username && x.Password == Password);
    }
}