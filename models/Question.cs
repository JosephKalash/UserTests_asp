


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserTests.models
{

    public class Question : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public QuestionType Type { get; set; } = QuestionType.Single;
        [Required]
        public int TestId { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }
        [JsonIgnore]
        public ICollection<Option> Options { get; set; }
    }
}

public enum QuestionType
{
    Single,
    Multiple
}