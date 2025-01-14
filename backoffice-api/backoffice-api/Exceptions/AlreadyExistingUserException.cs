namespace backoffice_api.Exceptions;

public class AlreadyExistingUserException : Exception
{
    public AlreadyExistingUserException() {}

    public AlreadyExistingUserException(string message) : base(message) {}
    
    public AlreadyExistingUserException(string message, Exception innerException) : base(message, innerException) {}
}