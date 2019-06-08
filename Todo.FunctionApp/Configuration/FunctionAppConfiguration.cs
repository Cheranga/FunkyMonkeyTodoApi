using System;
using System.Net.Http;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using FunctionMonkey.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Todo.DAL;
using Todo.FunctionApp.ResponseHandlers;
using Todo.Services;
using Todo.Services.DTO.Requests;

namespace Todo.FunctionApp.Configuration
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DatabaseConnection");

            builder.Setup((services, commandRegistry) =>
            {
                services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

                services.UseTodoServices(commandRegistry);
                services.UseTodoInMemoryDataAccess(new DbConfig {ConnectionString = connectionString});
            })
                .OpenApiEndpoint(apiBuilder =>
                {
                    apiBuilder.Title("Todo API")
                        .Version("V1")
                        .UserInterface();
                })
                .AddFluentValidation()
                .DefaultHttpResponseHandler<DefaultResponseHandler>()
                .Functions(functionBuilder =>
                {
                    //
                    // Bind the HTTP functions
                    //
                    functionBuilder.HttpRoute("todos", httpFunctionBuilder =>
                    {
                        httpFunctionBuilder.HttpFunction<CreateTodoRequest>(AuthorizationTypeEnum.Function,HttpMethod.Post)
                            .Options(optionsBuilder => optionsBuilder.ResponseHandler<CreateTodoResponseHandler>());

                        httpFunctionBuilder.HttpFunction<GetTasksRequest>(AuthorizationTypeEnum.Function, HttpMethod.Get)
                            .Options(optionsBuilder => optionsBuilder.ResponseHandler<GetTasksResponseHandler>());
                    });
                });
        }
    }
}
