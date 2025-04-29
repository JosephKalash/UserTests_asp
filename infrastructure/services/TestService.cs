
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserTests.models;

public interface ITestService
{
    public Task<List<Test>> GetTests();
    public Task<TestResponseDto?> GetTest(string id);
    public Task<TestResponseDto> AddTest(CreateTestDto test);
    Task<Test?> EditTest(string id, UpdateTestDto updatedTest);
    Task<string?> DeleteTest(string id);
}

public class TestService(TestDbContext context, IMapper mapper) : ITestService

{
    private readonly IMapper _mapper = mapper;
    private readonly TestDbContext _context = context;
    public async Task<TestResponseDto> AddTest(CreateTestDto dto)
    {
        var test = new Test { Title = dto.Title, Duration = dto.Duration, Questions = [] };
        foreach (var questionDto in dto.Questions)
        {
            var question = new Question { Text = questionDto.Text, TestId = test.Id, Type = questionDto.Type, Options = [] };
            foreach (var optionDto in questionDto.Options)
            {
                var option = new Option { Text = optionDto.Text, QuestionId = question.Id, IsCorrect = optionDto.IsCorrect };
                question.Options.Add(option);
            }
            test.Questions.Add(question);
        }
        _context.Tests.Add(test);
        await _context.SaveChangesAsync();
        var test_ = await _context.Tests.Include(t => t.Questions).ThenInclude(q => q.Options).Where(x => x.Id == test.Id).FirstOrDefaultAsync();
        var testResponse = _mapper.Map<Test, TestResponseDto>(test_!);
        return testResponse;
    }


    public async Task<TestResponseDto> GetTest(string id)
    {
        var test_ = await _context.Tests.Include(t => t.Questions).ThenInclude(q => q.Options).Where(x => x.Id == id).FirstOrDefaultAsync();
        if (test_ == null)
            throw new NotFoundException();
        var testResponse = _mapper.Map<Test, TestResponseDto>(test_);
        return testResponse;
    }

    public Task<List<Test>> GetTests()
    {
        return _context.Tests.ToListAsync();
    }

    public async Task<Test?> EditTest(string id, UpdateTestDto dto)
    {
        var test = await _context.Tests.FindAsync(id);

        if (test == null)
            return null;

        if (dto.Title is not null)
            test.Title = dto.Title;

        if (dto.Duration.HasValue)
            test.Duration = dto.Duration.Value;

        await _context.SaveChangesAsync();
        return test;
    }

    public async Task<string?> DeleteTest(string id)
    {
        var test = await _context.Tests.FindAsync(id);

        if (test == null)
            return null;

        _context.Tests.Remove(test);
        await _context.SaveChangesAsync();
        return id;
    }
}
