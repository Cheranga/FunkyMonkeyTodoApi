using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Commanding.Abstractions.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Todo.FunctionApp.ResponseHandlers
{
    public class GenericResponseHandler<TCustomCommand, TCustomResponse> : DefaultResponseHandler where TCustomCommand : class, ICommand<TCustomResponse> where TCustomResponse : class
    {
        public GenericResponseHandler(ILogger<GenericResponseHandler<TCustomCommand,TCustomResponse>> logger) : base(logger)
        {
        }

        public virtual Task<IActionResult> GetResponseFromException(TCustomCommand command, Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Task.FromResult<IActionResult>(new BadRequestResult());
        }

        public virtual Task<IActionResult> GetResponse(TCustomCommand command, TCustomResponse result)
        {
            if (result == null)
            {
                return Task.FromResult<IActionResult>(new BadRequestResult());
            }

            return Task.FromResult<IActionResult>(new OkObjectResult(result));
        }

        public virtual Task<IActionResult> GetResponse(TCustomCommand command)
        {
            return Task.FromResult<IActionResult>(new NoContentResult());
        }

        public virtual Task<IActionResult> GetValidationFailureResponse(TCustomCommand command, ValidationResult validationResult)
        {
            Logger.LogError(JsonConvert.SerializeObject(validationResult));
            return Task.FromResult<IActionResult>(new BadRequestObjectResult(validationResult));
        }

        public override Task<IActionResult> CreateResponse<TCommand, TResult>(TCommand command, TResult result)
        {
            return GetResponse(command as TCustomCommand, result as TCustomResponse);
        }

        public override Task<IActionResult> CreateResponseFromException<TCommand>(TCommand command, Exception ex)
        {
            return GetResponseFromException(command as TCustomCommand, ex);
        }

        public override Task<IActionResult> CreateResponse<TCommand>(TCommand command)
        {
            return GetResponse(command as TCustomCommand);
        }

        public override Task<IActionResult> CreateValidationFailureResponse<TCommand>(TCommand command, ValidationResult validationResult)
        {
            return GetValidationFailureResponse(command as TCustomCommand, validationResult);
        }
    }
}