using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserTests.models
{
    public class Test : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public int? Duration { get; set; }

        [JsonIgnore]
        public ICollection<UserTest> UserTests { get; set; }
        [JsonIgnore]
        public ICollection<Question> Questions { get; set; }

    }
}