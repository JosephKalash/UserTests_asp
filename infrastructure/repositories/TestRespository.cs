


using UserTests.models;

public class TestRepository : ITestRepository
{
    public Task<Question> AddQuestion(string testId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Question>> GetQuestions(string testId)
    {
        throw new NotImplementedException();
    }
}