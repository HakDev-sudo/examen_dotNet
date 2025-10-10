using examen_2.Models;
using examen_2.Respository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace examen_2.Respository.Implements;

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