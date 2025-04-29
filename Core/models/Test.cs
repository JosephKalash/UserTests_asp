using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FluentValidation;

namespace UserTests.models
{
    public class Test : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public int? Duration { get; set; }

        [JsonIgnore]
        public ICollection<UserTest> UserTests { get; set; }
        // [JsonIgnore]
        public List<Question> Questions { get; set; } = [];

    }

}