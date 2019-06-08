using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Todo.Domain;

namespace Todo.DAL
{
    public interface ITodoRepository
    {
        Task<Domain.Models.Todo> CreateTodoAsync(Domain.Models.Todo task);
        Task<bool> UpdateTodoAsync(Domain.Models.Todo task);
        Task<PagedModelCollection<Domain.Models.Todo>> GetTodosAsync(Paging paging);
    }
}