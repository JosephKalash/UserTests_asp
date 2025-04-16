
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserTests.models
{
    public class UserAnswer : BaseEntity
    {
        [Required]
        public int UserTestId { get; set; }
        [Required]
        public int OptionId { get; set; }

        [JsonIgnore]
        public UserTest UserTest { get; set; }
        [JsonIgnore]
        public Option Option { get; set; }
    }
}