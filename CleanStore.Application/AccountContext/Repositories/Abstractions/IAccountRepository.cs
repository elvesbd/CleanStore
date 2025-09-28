using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Application.SharedContext.Repositories.Abstractions;

namespace CleanStore.Application.AccountContext.Repositories.Abstractions;

public interface IAccountRepository : IRepository<Account>
{
    Task<bool> VerifyEmailExistsAsync(string email);
    Task SaveAsync(Account account);
}