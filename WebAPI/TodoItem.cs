
namespace WebAPI
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public static List<TodoItem> TodoItems = new List<TodoItem>();

        public TodoItem(int ID, string title, bool IsDone)
        {
        }

        public static void FillList()
        {
            TodoItems.AddRange(new List<TodoItem>()
            {
                new TodoItem(1,"Swagger testen",true),
                new TodoItem(2,"REST API verstehen",true),
                new TodoItem(3,"Todo Controller erweitern",false),
                new TodoItem(1,"Git Branches üben",true),
            });
        }

        internal static void DeleteToDo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
