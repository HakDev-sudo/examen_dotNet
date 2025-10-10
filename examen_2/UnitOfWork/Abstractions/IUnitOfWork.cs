using examen_2.Respository.Abstractions;

namespace examen_2.UnitOfWork.Abstractions;

public interface IUnitOfWork: IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

    // primero ejercicio
    IClientRepository Clients { get; }
    
    // para el segundo ejercicio
    IProductRepositoy Products { get; }
    
    // añadimos la prpiedad para nuestro repositorio específico 
    Task<int> CompleteAsync(); 
}