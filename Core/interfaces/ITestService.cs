
using UserTests.models;

public interface ITestService
{
    public Task<List<Test>> GetTests();
    public Task<List<Question>> GetQuestionts(string testId);
    public Task<List<Option>> GetOptions(string questionId);
    public Task<TestResponseDto?> GetTest(string id);
    public Task<TestResponseDto> AddTest(CreateTestDto test);
    Task<Test?> UpdateTest(string id, UpdateTestDto updatedTest);
    Task<string?> DeleteTest(string id);
}