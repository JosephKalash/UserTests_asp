

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTests.models;

namespace UserTests.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TestController(ITestService testService) : ControllerBase
{
    private readonly ITestService _testService = testService;

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Test>>> GetAll()
    {
        var tests = await _testService.GetTests();
        return Ok(tests);
    }
    [HttpGet("questions/{testId}")]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(string testId)
    {
        var questions = await _testService.GetQuestionts(testId);
        return Ok(questions);
    }
    [HttpGet("options/{questionId}")]
    public async Task<ActionResult<IEnumerable<Option>>> GetOptions(string questionId)
    {
        var options = await _testService.GetOptions(questionId);
        return Ok(options);
    }
    [HttpPost]
    public async Task<ActionResult<Test>> AddTest([FromBody] CreateTestDto test)
    {
        var test_ = await _testService.AddTest(test);
        return CreatedAtAction(nameof(GetById), new { id = test_.Id }, test_);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Test>> GetById(string id)
    {
        var test = await _testService.GetTest(id);
        if (test == null) return NotFound();

        return Ok(test);
    }
    [HttpPatch("{id}")]
    public async Task<ActionResult> EditTest(string id, [FromBody] UpdateTestDto test)
    {
        var test_ = await _testService.UpdateTest(id, test);
        if (test_ == null) return NotFound();
        return Ok(test_);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTest(string id)
    {
        var id_ = await _testService.DeleteTest(id);
        if (id_ == null) return NotFound();
        return Ok(id_);
    }
}
// [HttpGet]
// public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(string testId)
// {
//     var questions = await _testService.Questions.Where(x => x.TestId == testId).ToListAsync();
//     return Ok(questions);
// }
// [HttpGet]
// public async Task<ActionResult<IEnumerable<Option>>> GetOptions(string questionId)
// {
//     var options = await _testService.Options.Where(x => x.QuestionId == questionId).ToListAsync();
//     return Ok(options);
// }
// [HttpGet]
// public async Task<ActionResult<IEnumerable<UserTest>>> GetUserTests(string userId)
// {
//     var tests = await _testService.UserTests.Where(x => x.UserId == userId).ToListAsync();
//     return Ok(tests);
// }
// [HttpPost]
// public async Task<ActionResult> SubmitUserTest([FromBody] UserTest userTest)
// {
//     var test = _testService.UserTests.Add(userTest);
//     System.Console.WriteLine(test);
//     await _testService.SaveChangesAsync();
//     return Ok(test);
// }