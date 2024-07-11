using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Activities.Delete;
public class DeleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid actId)
    {
        JourneyDbContext dbcontext = new();
        Activity? activity = dbcontext.Activities.FirstOrDefault(x => x.Id == actId && x.TripId == tripId)
            ?? throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);

        dbcontext.Activities.Remove(activity);
        dbcontext.SaveChanges();
    }
}
