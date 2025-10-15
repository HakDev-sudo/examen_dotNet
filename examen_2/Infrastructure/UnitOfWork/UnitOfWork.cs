using System.Collections;
using examen_2.Infrastructure.Data;
using examen_2.Domain.Interfaces;
using examen_2.Infrastructure.Repositories;

namespace examen_2.Infrastructure.UnitOfWork;

public class UnitOfWork:  IUnitOfWork
{
    private readonly ContextDbTienda _context;
    private Hashtable _respositories;
    
    public IClientRepository Clients { get; private set; }
    public IProductRepositoy Products { get; private set; }

    public UnitOfWork(ContextDbTienda context)
    {
        _context = context;
        Clients =  new  ClientRepository(_context);
        Products = new  ProductRepository(_context);

    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        // si es la primera vez que que pidimos un repo 
        if (_respositories == null)
        {
            _respositories = new Hashtable();
        }
       
        // obtenemos el nombre del tipo de entidad | Clave : Estudiante y Valor: Intancia del repo Generico 
        var type = typeof(TEntity).Name;
        if (!_respositories.ContainsKey(type))
        {
            // sino existe, creamos
            var repositoryType = typeof(GenericRepository<>);
            var respositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),  _context);
           
            // guradmos en el diccionario
            _respositories.Add(type, respositoryInstance);
           
        }
        return (IGenericRepository<TEntity>)_respositories[type];
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose(); 
    } 
}