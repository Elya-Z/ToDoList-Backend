namespace ToDoList.Common.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required bool IsCompleted { get; set; }

    }
}
