using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Application.SharedContext.Results;
using CleanStore.Domain.AccountContext.ValueObjects;
using CleanStore.Application.SharedContext.UseCases.Abstractions;
using CleanStore.Application.AccountContext.Repositories.Abstractions;
using CleanStore.Application.SharedContext.Repositories.Abstractions;

namespace CleanStore.Application.AccountContext.UseCases.Create;

public sealed class Handler(
    IAccountRepository accountRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var emailExists = await accountRepository.VerifyEmailExistsAsync(request.Email);
        if (emailExists) return Result.Failure<Response>(new Error("400", "Email já existe"));
        
        var email = Email.Create(request.Email);
        var account = Account.Create(email);
        
        await accountRepository.SaveAsync(account);
        await unitOfWork.CommitAsync();
        
        var response = new Response(account.Id, account.Email);
        return Result.Success<Response>(null);
    }    
}
