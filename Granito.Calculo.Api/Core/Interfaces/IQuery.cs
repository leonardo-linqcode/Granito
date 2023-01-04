using MediatR;

namespace Granito.Calculo.Api.Core.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
