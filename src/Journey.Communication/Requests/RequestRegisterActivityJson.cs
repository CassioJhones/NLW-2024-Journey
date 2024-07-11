namespace Journey.Communication.Requests;
/// <summary>
/// Modelo padrão para todas as Atividades
/// </summary>
public class RequestRegisterActivityJson
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
