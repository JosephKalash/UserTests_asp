using UserTests.models;

public interface ITestRepository
{
    public Task<List<Question>> GetQuestions(string testId);
    public Task<Question> AddQuestion(string testId);
}