using MediatR;
using CleanStore.Application.SharedContext.Results;

namespace CleanStore.Application.SharedContext.UseCases.Abstractions;
    
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IQueryResponse;