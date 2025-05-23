
public class AddUserTestDto
{
    public string UserId { get; set; }

    public string TestId { get; set; }

    public List<AddUserAnswerDto> UserAnswers { get; set; } = [];
}