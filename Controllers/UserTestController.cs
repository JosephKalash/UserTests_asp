

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTests.models;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserTestController(IUserTestRepository userTestRepository) : ControllerBase
{
    private readonly IUserTestRepository _userTestRepository = userTestRepository;


    [HttpPost]
    public async Task<UserTest> AddUserTest(AddUserTestDto dto)
    {
        return await _userTestRepository.AddUserTest(dto);
    }
    [HttpGet]
    public async Task<List<UserTest>> GetUserTests(string userId)
    {
        return await _userTestRepository.GetUserTests(userId);
    }

}