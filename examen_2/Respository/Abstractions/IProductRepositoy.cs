using examen_2.Models;

namespace examen_2.Respository.Abstractions;

public interface IProductRepositoy : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> ObtenerProductorMayorQue(decimal price);
    Task<IEnumerable<Product>> FilterProducByOrderId(int orderId);
    

}