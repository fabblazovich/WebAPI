namespace WebAPI.DTO
{
    public class CreateToDoRequest
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsDone { get; set; }
    }
}
