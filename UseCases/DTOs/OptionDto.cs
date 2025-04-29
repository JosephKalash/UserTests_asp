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
}