using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace UserTests.models
{
    public class TestResponseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int? Duration { get; set; }
        public List<QuestionResponseDto> Questions { get; set; } = [];
    }
    public class OptionResponseDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class CreateTestDto
    {
        [Required]
        public string Title { get; set; }

        public int? Duration { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "At least one question is required")]
        public List<AddQuestionDto> Questions { get; set; }
    }
    public class UpdateTestDto
    {
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters.")]
        public string? Title { get; set; }

        [Range(1, 300, ErrorMessage = "Duration must be between 1 and 300.")]
        public int? Duration { get; set; }
    }

    public class UpdateTestDtoValidator : AbstractValidator<UpdateTestDto>
    {
        public UpdateTestDtoValidator()
        {
            When(x => x.Title != null, () =>
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage("Title should not be empty");
            });
            When(x => x.Duration != null, () =>
            {
                RuleFor(x => x.Duration).GreaterThan(1).WithMessage("Duration must not be empty");
            });
        }
    }
}