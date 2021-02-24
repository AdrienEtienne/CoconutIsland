using MediatR;

namespace CoconutIsland.Ingredient.Application.Commands
{
    public abstract class Command<T> : IRequest<T> { }
}