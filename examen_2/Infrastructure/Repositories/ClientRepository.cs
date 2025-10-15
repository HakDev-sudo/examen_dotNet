using examen_2.Domain.Entities;
using examen_2.Domain.Interfaces;
using examen_2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace examen_2.Infrastructure.Repositories;

public class ClientRepository: GenericRepository<Client>, IClientRepository
{
     
    public ClientRepository(ContextDbTienda  context) :  base(context)
    {
        
    }

    public async Task<IEnumerable<Client>> GetAllClientsByContent(string name)
    {

        // EF.Functions.ILike => busca sin distinguir mayúsculas y tildes (PostgreSQL)
        var normalized = name.Trim().ToLower();

        // PostgreSQL: búsqueda sin distinción de mayúsculas/tildes
        return await _context.Clients
            .Where(c => EF.Functions.ILike(c.Name, $"%{normalized}%"))
            .ToListAsync();
    }
}