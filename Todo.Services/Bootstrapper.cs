using System;
using AzureFromTheTrenches.Commanding.Abstractions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Todo.Services.DTO.Assets;
using Todo.Services.DTO.Requests;
using Todo.Services.Mappers;
using Todo.Services.Validators;

namespace Todo.Services
{
    public static class Bootstrapper
    {
        public static void UseTodoServices(this IServiceCollection services, ICommandRegistry commandRegistry)
        {
            if (services == null || commandRegistry == null)
            {
                throw new Exception("Both services and the command registry are required");
            }

            commandRegistry.Discover(typeof(Bootstrapper).Assembly);

            services.AddTransient<IValidator<CreateTodoRequest>, CreateTodoRequestValidator>();
            services.AddTransient<IValidator<GetTasksRequest>, GetTasksRequestValidator>();

            services.AddScoped<IMapper<CreateTodoRequest, Domain.Models.Todo>, CreateTodoRequestToTodoMapper>();
            services.AddScoped<IMapper<Domain.Models.Todo, DisplayTodo>, TodoToDisplayTodoMapper>();
        }
    }
}
