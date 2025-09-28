using CleanStore.Domain.AccountContext.Events;
using CleanStore.Domain.SharedContext.Entities;
using CleanStore.Domain.AccountContext.ValueObjects;
using CleanStore.Domain.SharedContext.AggregateRoots.Abstractions;

namespace CleanStore.Domain.AccountContext.Entities;

public sealed class Account : Entity, IAggregateRoot
{
    public Email Email { get; private set; } = null!;

    private Account() : base(Guid.NewGuid()){}
    private Account(Guid id, Email email) : base(id)
    {
        Email = email;
    }

    public static Account Create(Email email)
    {
        var id = Guid.NewGuid();
        var account = new Account(id, email);
        account.RaiseDomainEvent(new OnAccountCreatedEvent(id, email));
        return account;
    }
}