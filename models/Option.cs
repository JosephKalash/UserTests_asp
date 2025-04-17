


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserTests.models
{
    public class Option : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public bool IsCorrect { get; set; } = false;
        [Required]
        public string QuestionId { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}