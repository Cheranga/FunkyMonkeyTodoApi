using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Todo.Services.DTO.Requests;
using Todo.Services.DTO.Responses;

namespace Todo.FunctionApp.ResponseHandlers
{
    public class GetTasksResponseHandler : GenericResponseHandler<GetTasksRequest,GetTasksResponse>
    {
        public GetTasksResponseHandler(ILogger<GetTasksResponseHandler> logger) : base(logger)
        {
        }

        public override Task<IActionResult> GetResponse(GetTasksRequest command, GetTasksResponse result)
        {
            if (result?.Collection?.Tasks == null || !result.Collection.Tasks.Any())
            {
                return Task.FromResult<IActionResult>(new NotFoundResult());
            }

            return Task.FromResult<IActionResult>(new OkObjectResult(result));
        }
    }
}