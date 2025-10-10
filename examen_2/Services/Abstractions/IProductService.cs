using examen_2.DTOs.Response;

namespace examen_2.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<ProducDto>>  ObtenerProductorMayorQue(decimal price);
    Task<IEnumerable<AllProductsDto>>  GetAllProducts();

    Task<IEnumerable<ProducDto>> GetProductsByOrderId(int id);

}