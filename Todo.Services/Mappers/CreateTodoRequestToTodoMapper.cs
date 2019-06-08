using System;
using Todo.Services.DTO.Requests;

namespace Todo.Services.Mappers
{
    public class CreateTodoRequestToTodoMapper : IMapper<CreateTodoRequest, Domain.Models.Todo>
    {
        public Domain.Models.Todo Map(CreateTodoRequest source)
        {
            if (source == null)
            {
                return null;
            }

            return new Domain.Models.Todo
            {
                Id = Guid.NewGuid().ToString(),
                Description = source.Description,
                IsCompleted = false,
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}
