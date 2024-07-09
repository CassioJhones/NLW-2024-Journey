using System.Net;

namespace Journey.Exception.ExceptionsBase;
public class ValidationException : JourneyException
{
    public ValidationException(string message) : base(message)
    {
    }

    public override HttpStatusCode GetStatusCode()
        => HttpStatusCode.BadRequest;
}
