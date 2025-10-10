using examen_2.DTOs.Response;

namespace examen_2.Services.Abstractions;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetClientsByContent(string name);
}