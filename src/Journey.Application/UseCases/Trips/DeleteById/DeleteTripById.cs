using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.DeleteById;
public class DeleteTripById
{
    public void Execute(Guid id)
    {
        JourneyDbContext dbContext = new();
        Trip? trips = dbContext.Trips.Include(x => x.Activities).FirstOrDefault(x => x.Id == id)
            ?? throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);

        dbContext.Trips.Remove(trips);
        dbContext.SaveChanges();
    }
}
