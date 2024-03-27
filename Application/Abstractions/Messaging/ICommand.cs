using MediatR;

namespace Showcase.CleanArchitecture.Application.Abstractions.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}