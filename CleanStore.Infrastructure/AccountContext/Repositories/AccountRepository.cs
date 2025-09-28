using Microsoft.EntityFrameworkCore;
using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Infrastructure.SharedContext.Data;
using CleanStore.Application.AccountContext.Repositories.Abstractions;

namespace CleanStore.Infrastructure.AccountContext.Repositories;

public class AccountRepository(AppDbContext context) : IAccountRepository
{
    public async Task<bool> VerifyEmailExistsAsync(string email)
        => await context.Accounts.AsNoTracking().AnyAsync(x => x.Email == email);

    public async Task SaveAsync(Account account) => await context.Accounts.AddAsync(account);
}