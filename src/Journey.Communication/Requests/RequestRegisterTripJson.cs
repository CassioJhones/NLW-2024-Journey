namespace Journey.Communication.Requests;
/// <summary>
/// Modelo padrão para todas as requisições de viagem
/// </summary>
public class RequestRegisterTripJson
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
