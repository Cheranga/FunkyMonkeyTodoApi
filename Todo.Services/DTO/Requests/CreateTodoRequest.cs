using AzureFromTheTrenches.Commanding.Abstractions;
using Todo.Services.DTO.Assets;

namespace Todo.Services.DTO.Requests
{
    public class CreateTodoRequest : ICommand<DisplayTodo>
    {
        public string Description { get; set; }
    }
}
