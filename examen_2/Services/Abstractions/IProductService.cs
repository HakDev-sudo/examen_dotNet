using examen_2.DTOs.Response;
using examen_2.Models;

namespace examen_2.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<ProducDto>>  ObtenerProductorMayorQue(decimal price);
    Task<IEnumerable<AllProductsDto>>  GetAllProducts();

    Task<IEnumerable<ProducDto>> GetProductsByOrderId(int id);
    Task<QuantityByOrderDto> GetTotalQuantityByOrderId(int orderId);
    Task<ProducDto?> GetMostExpensiveProduct();
    Task<IEnumerable<Orderdetail>> GetAllOrderDetails();
    Task<decimal> GetAveragePrice();
    Task<IEnumerable<ProductQuantityDto>> GetOrderDetailsProductQuantity();
    Task<IEnumerable<Product>> GetProductsWithoutDescription();
    Task<IEnumerable<Product>> GetProductsSoldToClient(int clientId);
    Task<IEnumerable<ClientOrdersCountDto>> GetClientWithMostOrders();
    Task<IEnumerable<string>> GetClientsWhoBoughtProduct(int productId);
    Task<IEnumerable<Order>> GetOrdersAfterDate(DateTime date);

}