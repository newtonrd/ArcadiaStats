using FluentValidation;

namespace ArcadiaStats.Application.Commands.TodoItems.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
