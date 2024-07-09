using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetAll;
public class GetAllTripsUseCase
{
    public List<Trip> Execute()
    {
        var dbContext = new JourneyDbContext();
        var trips = dbContext.Trips.ToList();

        return trips;
    }
}
