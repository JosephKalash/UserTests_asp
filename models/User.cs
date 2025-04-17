

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace UserTests.models
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public ICollection<UserTest> UserTests { get; set; }

        [JsonIgnore]
        public ICollection<UserAnswer> UserAnswers { get; set; }

    }
}