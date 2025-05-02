

using UserTests.models;

public interface IUserTestRepository
{
    public Task<UserTest> AddUserTest(AddUserTestDto userTest);
    public Task<List<UserTest>> GetUserTests(string userId);
}