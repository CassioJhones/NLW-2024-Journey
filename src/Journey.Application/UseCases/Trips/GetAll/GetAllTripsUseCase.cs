using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.GetAll;
public class GetAllTripsUseCase
{
    public List<Trip> Execute()
    {
        JourneyDbContext dbContext = new();
        List<Trip> trips = dbContext.Trips.ToList();

        return trips;
    }
}
