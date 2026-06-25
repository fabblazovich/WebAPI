
namespace WebAPI
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
