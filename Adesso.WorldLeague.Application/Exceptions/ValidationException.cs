namespace Adesso.WorldLeague.Application.Exceptions;

public class ValidationException : Exception
{
    public IReadOnlyCollection<ValidationError> Errors { get; init; }

    public ValidationException(IReadOnlyCollection<ValidationError> errors)
        : base("One or more validation failures have occured.")
    {
        Errors = errors;
    }
}

public record ValidationError(string PropertyName, string ErrorMessage);