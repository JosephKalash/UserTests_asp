using System.ComponentModel.DataAnnotations;

namespace UserTests.models
{
    public class BaseEntity
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}