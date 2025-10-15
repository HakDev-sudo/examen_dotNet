using examen_2.Domain.Entities;

namespace examen_2.Domain.Interfaces;

public interface IClientRepository: IGenericRepository<Client>
{
    Task<IEnumerable<Client>> GetAllClientsByContent(string name);
}