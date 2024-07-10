using System.Net;

namespace Journey.Exception.ExceptionsBase;
public class ValidationException : JourneyException
{
    private readonly IList<string> _errors;
    public ValidationException(IList<string> messages) : base(string.Empty)
        => _errors = messages;
    
    public override IList<string> GetErrorMessages()
        => _errors;

    public override HttpStatusCode GetStatusCode()
        => HttpStatusCode.BadRequest;
}
