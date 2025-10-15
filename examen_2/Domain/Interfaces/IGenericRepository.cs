namespace examen_2.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    
    Task AddAsync(T entity);
    
    // esta función (rompe) el patron de unit of work
    // pero segun el lab se dice que implementemos esto
    void Update(T entity);
    void Delete(T entity); 
}