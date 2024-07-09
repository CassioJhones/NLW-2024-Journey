using Journey.Communication.Responses;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById;
public class GetTripByIdUseCase
{
    public ResponseTripJson Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();
        var trips = dbContext.Trips.Include(x => x.Activities).FirstOrDefault(x => x.Id == id);

        return new ResponseTripJson
        {
            Id = trips.Id,
            Name = trips.Name,
            StartDate = trips.StartDate,
            EndDate = trips.EndDate,
            Activities = trips.Activities.Select(atividade => new ResponseActivityJson
            {
                Id = atividade.Id,
                Name = atividade.Name,
                Date = atividade.Date,
                Status = (Communication.Enums.ActivityStatus)atividade.Status,

            }).ToList(),
        };
    }
}
