using MediatR;

namespace Granito.Taxas.Api.Core.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
