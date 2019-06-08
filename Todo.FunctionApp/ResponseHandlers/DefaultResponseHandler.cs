using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Abstractions.Http;
using FunctionMonkey.Commanding.Abstractions.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Todo.FunctionApp.ResponseHandlers
{
    public class DefaultResponseHandler : IHttpResponseHandler
    {
        protected ILogger<DefaultResponseHandler> Logger;

        public DefaultResponseHandler(ILogger<DefaultResponseHandler> logger)
        {
            Logger = logger;
        }

        public virtual Task<IActionResult> CreateResponseFromException<TCommand>(TCommand command, Exception ex) where TCommand : ICommand
        {
            Logger.LogError(ex.ToString());
            return Task.FromResult<IActionResult>(new BadRequestResult());
        }

        public virtual Task<IActionResult> CreateResponse<TCommand, TResult>(TCommand command, TResult result) where TCommand : ICommand<TResult>
        {
            if (result == null)
            {
                return Task.FromResult<IActionResult>(new NoContentResult());
            }

            return Task.FromResult<IActionResult>(new OkObjectResult(result));
        }

        public virtual Task<IActionResult> CreateResponse<TCommand>(TCommand command)
        {
            return Task.FromResult<IActionResult>(new NoContentResult());
        }

        public virtual Task<IActionResult> CreateValidationFailureResponse<TCommand>(TCommand command, ValidationResult validationResult) where TCommand : ICommand
        {
            Logger.LogError(JsonConvert.SerializeObject(validationResult));
            return Task.FromResult<IActionResult>(new BadRequestObjectResult(validationResult));
        }

    }
}
