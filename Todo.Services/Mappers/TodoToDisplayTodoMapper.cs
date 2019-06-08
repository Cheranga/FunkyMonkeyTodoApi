using DisplayTodo = Todo.Services.DTO.Assets.DisplayTodo;

namespace Todo.Services.Mappers
{
    public class TodoToDisplayTodoMapper : IMapper<Domain.Models.Todo, DisplayTodo>
    {
        public DisplayTodo Map(Domain.Models.Todo source)
        {
            if (source == null)
            {
                return null;
            }

            return new DisplayTodo(source.Id, source.Description, source.IsCompleted);
        }
    }
}