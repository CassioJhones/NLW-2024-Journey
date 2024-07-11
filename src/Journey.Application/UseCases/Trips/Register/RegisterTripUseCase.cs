using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register;
public class RegisterTripUseCase
{
    public ResponseShortTripJson Execute(RequestRegisterTripJson request)
    {
        Validate(request);
        JourneyDbContext dbContext = new();
        Trip entity = new()
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        dbContext.Trips.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            Id = entity.Id,
            EndDate = entity.EndDate,
            StartDate = entity.StartDate,
            Name = entity.Name,
        };
    }

    private void Validate(RequestRegisterTripJson request)
    {
        RegisterTripValidator validator = new();
        FluentValidation.Results.ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errorMessageList = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationException(errorMessageList);
        }
    }
}
