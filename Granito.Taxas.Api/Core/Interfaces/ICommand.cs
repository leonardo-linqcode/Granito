using MediatR;

namespace Granito.Taxas.Api.Core.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse> { };