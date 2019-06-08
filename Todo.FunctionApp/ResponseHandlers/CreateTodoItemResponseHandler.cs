using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Services.DTO.Assets;
using Todo.Services.DTO.Requests;

namespace Todo.FunctionApp.ResponseHandlers
{
    public class CreateTodoResponseHandler : GenericResponseHandler<CreateTodoRequest, DisplayTodo>
    {
        public CreateTodoResponseHandler(ILogger<CreateTodoResponseHandler> logger) : base(logger)
        {
        }

        public override Task<IActionResult> GetResponse(CreateTodoRequest command, DisplayTodo result)
        {
            return Task.FromResult<IActionResult>(new OkObjectResult(result) {StatusCode = (int) HttpStatusCode.Created});
        }
    }
}