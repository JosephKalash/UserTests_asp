
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserTests.models
{
    public class UserAnswer : BaseEntity
    {
        [Required]
        public string UserTestId { get; set; }
        [Required]
        public string OptionId { get; set; }
        [Required]
        public string QuestionId { get; set; }

        [JsonIgnore]
        public UserTest UserTest { get; set; }
        public Option Option { get; set; }
        public Question Question { get; set; }
    }
}