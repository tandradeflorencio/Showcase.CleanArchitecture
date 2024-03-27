using MediatR;

namespace Showcase.CleanArchitecture.Application.Abstractions.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}