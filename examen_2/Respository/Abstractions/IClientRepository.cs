using examen_2.Models;

namespace examen_2.Respository.Abstractions;

public interface IClientRepository: IGenericRepository<Client>
{
    Task<IEnumerable<Client>> GetAllClientsByContent(string name);
}