namespace Journey.Exception.ExceptionsBase;
public class ValidationException : JourneyException
{
    public ValidationException(string message) : base(message)
    {
    }
}
