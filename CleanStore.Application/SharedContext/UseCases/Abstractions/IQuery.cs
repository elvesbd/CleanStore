using MediatR;
using CleanStore.Application.SharedContext.Results;

namespace CleanStore.Application.SharedContext.UseCases.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse;