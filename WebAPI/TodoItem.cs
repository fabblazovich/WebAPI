namespace WebAPI
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        public bool IsDone { get; set; }

        public static List<TodoItem> Items { get; set; }
    }
}
