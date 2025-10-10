using examen_2.Models;

namespace examen_2.Respository.Abstractions;

public interface IProductRepositoy : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> ObtenerProductorMayorQue(decimal price);
    Task<IEnumerable<Product>> FilterProducByOrderId(int orderId);
    Task<int> GetTatalQuntityOrderIdAsyn(int orderId);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<IEnumerable<Orderdetail>> GetAllOrderDetailsAsync();
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId);

}