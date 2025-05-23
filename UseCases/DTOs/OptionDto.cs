using System.ComponentModel.DataAnnotations;

namespace UserTests.models
{

    public class AddOptionDto
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }

    public class OptionResponseDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}