

using System.ComponentModel.DataAnnotations;

namespace UserTests.models
{
    public class AddQuestionDto
    {
        [Required]
        public string Text { get; set; }
        public QuestionType Type { get; set; } = QuestionType.Single;
        [MinLength(2, ErrorMessage = "Options count must be greater than 1")]
        public List<AddOptionDto> Options { get; set; }
    }

    public class QuestionResponseDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<OptionResponseDto> Options { get; set; } = [];
    }
}