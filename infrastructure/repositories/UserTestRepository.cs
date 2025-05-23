using Microsoft.EntityFrameworkCore;
using UserTests.models;

public class UserTestRepository(TestDbContext context) : IUserTestRepository
{
    private readonly TestDbContext _context = context;
    public async Task<UserTest> AddUserTest(AddUserTestDto dto)
    {
        var userTest = new UserTest { UserId = dto.UserId, TestId = dto.TestId };
        if ((await _context.Tests.FindAsync(dto.TestId)) == null)
            throw new NotFoundException();
        userTest.UserAnswers = [];
        var questionsCount = 0;
        foreach (var userAnswerDto in dto.UserAnswers)
        {
            var userAnswer = new UserAnswer { UserTestId = userTest.Id, QuestionId = userAnswerDto.QuestionId, OptionId = userAnswerDto.OptionId };
            ///TODO: check if the answer is correct and increase the score property
            var originalOption = await _context.Options.Where(o => o.Id == userAnswerDto.OptionId).FirstOrDefaultAsync();
            questionsCount++;
            if (originalOption!.IsCorrect)
                userTest.Score++;
            userTest.UserAnswers.Add(userAnswer);
        }
        userTest.Score /= questionsCount;
        userTest.Score *= 100;
        _context.UserTests.Add(userTest);
        await _context.SaveChangesAsync();
        return userTest;

    }

    public Task<List<UserTest>> GetUserTests(string userId)
    {
        return _context.UserTests.Where(uT => uT.UserId == userId).Include(uT => uT.UserAnswers).ThenInclude(uA => uA.Question)
                                                                    .Include(uT => uT.UserAnswers).ThenInclude(uA => uA.Option)
                                                                    .ToListAsync();
    }
}