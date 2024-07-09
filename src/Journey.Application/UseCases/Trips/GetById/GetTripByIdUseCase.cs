using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById;
public class GetTripByIdUseCase
{
    public ResponseTripJson Execute(Guid id)
    {
        JourneyDbContext dbContext = new();
        Trip? trips = dbContext.Trips.Include(x => x.Activities).FirstOrDefault(x => x.Id == id);

        return trips is null
            ? throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND)
            : new ResponseTripJson
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
