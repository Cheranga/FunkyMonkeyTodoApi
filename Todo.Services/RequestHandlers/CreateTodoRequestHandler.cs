using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.Extensions.Logging;
using Todo.DAL;
using Todo.Services.DTO.Requests;
using Todo.Services.Mappers;
using DisplayTodo = Todo.Services.DTO.Assets.DisplayTodo;

namespace Todo.Services.RequestHandlers
{
    internal class CreateTodoRequestHandler : ICommandHandler<CreateTodoRequest, DisplayTodo>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper<CreateTodoRequest, Domain.Models.Todo> _requestToModelMapper;
        private readonly IMapper<Domain.Models.Todo, DisplayTodo> _todoToDisplayTodoMapper;
        private readonly ILogger<CreateTodoRequestHandler> _logger;


        public CreateTodoRequestHandler(ITodoRepository repository, IMapper<CreateTodoRequest, Domain.Models.Todo> requestToModelMapper,
            IMapper<Domain.Models.Todo,DisplayTodo> todoToDisplayTodoMapper, ILogger<CreateTodoRequestHandler> logger)
        {
            _repository = repository;
            _requestToModelMapper = requestToModelMapper;
            _todoToDisplayTodoMapper = todoToDisplayTodoMapper;
            _logger = logger;
        }

        public async Task<DisplayTodo> ExecuteAsync(CreateTodoRequest command, DisplayTodo previousResult)
        {
            _logger.LogInformation("Creating todo item");

            var task = await _repository.CreateTodoAsync(_requestToModelMapper.Map(command));

            var displayTodo = _todoToDisplayTodoMapper.Map(task);

            return displayTodo;
        }
    }
}
