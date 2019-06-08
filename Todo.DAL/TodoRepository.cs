using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Todo.DAL.Extensions;
using Todo.Domain;

namespace Todo.DAL
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly DbConfig _config;
        private readonly ILogger<InMemoryTodoRepository> _logger;
        private readonly List<Domain.Models.Todo> _todos;

        public InMemoryTodoRepository(DbConfig config, ILogger<InMemoryTodoRepository> logger)
        {
            if (config == null)
            {
                _logger.LogError("Invalid configuration");
                throw new ArgumentNullException(nameof(config));
            }

            _config = config;
            _logger = logger;
            _todos = new List<Domain.Models.Todo>();
        }

        public Task<Domain.Models.Todo> CreateTodoAsync(Domain.Models.Todo task)
        {
           _todos.Add(task);
           return Task.FromResult(task);
        }

        public Task<bool> UpdateTodoAsync(Domain.Models.Todo task)
        {
            var existingTask = _todos.FirstOrDefault(x => x.Id == task.Id);
            if (existingTask == null)
            {
                _logger.LogWarning($"Task cannot be found to update: {task.Id}");
                return Task.FromResult(false);
            }

            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            return Task.FromResult(true);
        }

        public Task<PagedModelCollection<Domain.Models.Todo>> GetTodosAsync(Paging paging)
        {
            var requiredTasks = _todos.ToPaging(paging, todo => todo.Description, _logger);

            var collection = new PagedModelCollection<Domain.Models.Todo>(_todos.Count, paging.Page, paging.PageSize, requiredTasks);

            return Task.FromResult(collection);
        }
    }
}
