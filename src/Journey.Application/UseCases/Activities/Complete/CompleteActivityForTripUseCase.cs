using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Enums;

namespace Journey.Application.UseCases.Activities.Complete;
public class CompleteActivityForTripUseCase
{
    public void Execute(Guid tripiD, Guid activId)
    {
        JourneyDbContext dbcontext = new();
        Activity? activity = dbcontext.Activities.FirstOrDefault(x => x.Id == activId && x.TripId == tripiD)
            ?? throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);

        activity.Status = ActivityStatus.Done;
        dbcontext.Activities.Update(activity);
        dbcontext.SaveChanges();
    }
}
