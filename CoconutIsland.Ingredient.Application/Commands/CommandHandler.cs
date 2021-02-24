using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace CoconutIsland.Ingredient.Application.Commands
{
    public abstract class CommandHandler<TRequest, TResponse, TRequestValidator>
        : IRequestHandler<TRequest, TResponse>
        where TRequest : Command<TResponse> where TRequestValidator : AbstractValidator<TRequest>
    {
        protected readonly TRequestValidator Validator;

        protected CommandHandler(TRequestValidator validator)
        {
            this.Validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await this.Validator.ValidateAsync(request, cancellationToken);

            if ( !validationResult.IsValid )
                throw new ValidationException("Command not valid.", validationResult.Errors);

            return await this.Process(request, cancellationToken);
        }

        public abstract Task<TResponse> Process(TRequest request,
                                                CancellationToken cancellationToken);
    }
}