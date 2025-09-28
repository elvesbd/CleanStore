using MediatR;
using CleanStore.Application.SharedContext.Results;

namespace CleanStore.Application.SharedContext.UseCases.Abstractions;

public interface ICommand : IRequest<Result>;
public interface ICommand<TCommandResponse> : IRequest<Result<TCommandResponse>> where TCommandResponse : ICommandResponse;
