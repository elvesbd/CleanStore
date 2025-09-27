namespace CleanStore.Domain.AccountContext.Exceptions;

public abstract class ErrorMessages
{
    public static EmailErrorMessages Email { get; } = new();

    public class EmailErrorMessages
    {
        public string Invalid { get; } = "E-mail inválido";
        public string NullOrEmpty { get; } = "E-mail não pode ser nulo ou vazio.";
    }
}