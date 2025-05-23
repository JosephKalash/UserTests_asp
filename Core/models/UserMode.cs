
public class UserRegister
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; } = false;
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}