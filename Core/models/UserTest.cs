

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserTests.models
{
    public class UserTest : BaseEntity
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string TestId { get; set; }
        public int Score { get; set; } = 0;
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }
    }

}