using MediatR;

namespace Granito.Calculo.Api.Core.Interfaces;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
{ }