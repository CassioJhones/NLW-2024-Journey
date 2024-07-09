using Journey.Communication.Requests;

namespace Journey.Application.UseCases.Trips.Register;
public class RegisterTripUseCase
{
    
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Nome não pode ser vazio");
        }
        if(request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new ArgumentException("Data Inválida");
        }

        if (request.EndDate.Date < request.StartDate.Date)
        {
            throw new ArgumentException("a viagem deve terminar após a data de inicio");
        }
    }

}
