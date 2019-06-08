using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Todo.Services.DTO.Requests;

namespace Todo.Services.Validators
{
    internal class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest>
    {
        public CreateTodoRequestValidator()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull();
        }
    }
}
