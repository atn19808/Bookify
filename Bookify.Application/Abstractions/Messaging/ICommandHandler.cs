using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
	public interface ICommandHandler<TCommand> : IRequsetHandler<TCommand, Result> where TCommand : ICommand
	{
	}

	public interface ICommandHandler<ICommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse> { }
}
