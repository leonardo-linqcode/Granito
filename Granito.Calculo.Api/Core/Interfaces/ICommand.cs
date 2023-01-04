using MediatR;

namespace Granito.Calculo.Api.Core.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse> { };