namespace Todo.Services.DTO.Assets
{
    public class DisplayTodo
    {
        public DisplayTodo(string id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        public string Id { get; }
        public string Description { get; }
        public bool IsCompleted { get; }
    }
}