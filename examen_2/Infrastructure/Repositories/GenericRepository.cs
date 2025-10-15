using examen_2.Infrastructure.Data;
using examen_2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace examen_2.Infrastructure.Repositories;
public class GenericRepository<T>: IGenericRepository<T> where T: class
{
    protected readonly ContextDbTienda _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ContextDbTienda context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    // Esta funcion se usará par insertar
    // pero no se guardará los cambios desde aquí 
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    
    public void Update(T entity) => _dbSet.Update(entity);
    
    public void Delete(T entity) => _dbSet.Remove(entity);  
    // Ahora según el lab pide un funcion que se inmplemnta el 
    // saveChanges
    public async Task AddAndSaveAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await  _context.SaveChangesAsync();
    }
}