using System.Linq;
using Todo.Services.DTO.Assets;

namespace Todo.Services.DTO.Responses
{
    public class GetTasksResponse
    {
        public DisplayTasksCollection Collection { get; }

        public GetTasksResponse(DisplayTasksCollection collection)
        {
            Collection = collection;
        }

        public static GetTasksResponse Empty()
        {
            return new GetTasksResponse(new DisplayTasksCollection(0,0,0, Enumerable.Empty<DisplayTodo>())); 
        }
    }
}
