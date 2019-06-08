using FluentValidation;
using Todo.Services.DTO.Requests;

namespace Todo.Services.Validators
{
    internal class GetTasksRequestValidator : AbstractValidator<GetTasksRequest>
    {
        public GetTasksRequestValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        }
    }
}