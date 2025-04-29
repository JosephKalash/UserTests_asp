


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserTests.models
{

    public class Question : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        public QuestionType Type { get; set; } = QuestionType.Single;
        [Required]
        public string TestId { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }
        // [JsonIgnore]
        public List<Option> Options { get; set; } = [];
    }

}

public enum QuestionType
{
    Single,
    Multiple
}