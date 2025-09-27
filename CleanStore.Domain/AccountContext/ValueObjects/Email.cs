using System.Text.RegularExpressions;
using CleanStore.Domain.AccountContext.Exceptions;
using CleanStore.Domain.SharedContext.Extensions;
using CleanStore.Domain.SharedContext.ValueObjects;

namespace CleanStore.Domain.AccountContext.ValueObjects;

public partial record Email : ValueObject
{
    public const int MinLength = 6;
    public const int MaxLength = 160;
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    
    public string Address { get; private set; } = string.Empty;
    public string Hash { get; private set; } = string.Empty;
    
    private Email(){}

    private Email(string address, string hash)
    {
        Address = address;
        Hash = hash;
    }
    
    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            throw new EmailNullOrEmptyException(ErrorMessages.Email.NullOrEmpty);
        
        address = address.Trim();
        address = address.ToLower();
        
        if (!EmailRegex().IsMatch(address))
            throw new InvalidEmailException(ErrorMessages.Email.Invalid);

        return new Email(address, address.ToBase64());
    }
    
    public static implicit operator string(Email email) => email.ToString();
    public override string ToString() => Address;
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}