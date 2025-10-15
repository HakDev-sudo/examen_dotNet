using examen_2.Application.DTOs.Response;

namespace examen_2.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetClientsByContent(string name);
}