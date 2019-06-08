using AzureFromTheTrenches.Commanding.Abstractions;
using Todo.Domain;
using Todo.Services.DTO.Responses;

namespace Todo.Services.DTO.Requests
{
    public class GetTasksRequest : ICommand<GetTasksResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}