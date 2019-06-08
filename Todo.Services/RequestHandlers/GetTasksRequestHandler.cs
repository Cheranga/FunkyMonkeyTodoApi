using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Todo.DAL;
using Todo.Domain;
using Todo.Services.DTO.Assets;
using Todo.Services.DTO.Requests;
using Todo.Services.DTO.Responses;
using Todo.Services.Mappers;

namespace Todo.Services.RequestHandlers
{
    internal class GetTasksRequestHandler : ICommandHandler<GetTasksRequest, GetTasksResponse>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper<Domain.Models.Todo, DisplayTodo> _mapper;
        private readonly ILogger<GetTasksRequestHandler> _logger;

        public GetTasksRequestHandler(ITodoRepository repository, IMapper<Domain.Models.Todo, DisplayTodo> mapper, ILogger<GetTasksRequestHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetTasksResponse> ExecuteAsync(GetTasksRequest command, GetTasksResponse previousResult)
        {
            var tasks = await _repository.GetTodosAsync(new Paging
            {
                Page = command.Page,
                PageSize = command.PageSize
            });

            if (!(tasks?.Tasks?.Any()).GetValueOrDefault(false))
            {
                return GetTasksResponse.Empty();
            }

            var displayTodos = tasks.Tasks.Select(x => _mapper.Map(x)).ToList();
            return new GetTasksResponse(new DisplayTasksCollection(tasks.TotalCount,command.Page, command.PageSize, displayTodos));
        }
    }
}
