using examen_2.DTOs.Response;
using examen_2.Services.Abstractions;
using examen_2.UnitOfWork.Abstractions;

namespace examen_2.Services.Implements;

public class ProductoService: IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProducDto>>  ObtenerProductorMayorQue(decimal price)
    {
        var products = await _unitOfWork.Products.ObtenerProductorMayorQue(price);

        if (products == null || !products.Any())
        {
            Console.WriteLine("No se encontraron productos");
            return Enumerable.Empty<ProducDto>();
        }

        Console.WriteLine($"Se encontraron {products.Count()} productos");

        return products.Select(c => new ProducDto
        {
            Name = c.Name,
            Price = c.Price
        }); 
    }

    public async Task<IEnumerable<AllProductsDto>> GetAllProducts()
    {
        var allProducts = await _unitOfWork.Products.GetAllAsync();
        return allProducts.Select(p => new AllProductsDto
        {
            Price = p.Price,
            ProducName = p.Name,
            ProducId = p.Productid
        });
    }

    public async Task<IEnumerable<ProducDto>> GetProductsByOrderId(int id)
    {
        var products = await _unitOfWork.Products.FilterProducByOrderId(id);
        if (products == null) return Enumerable.Empty<ProducDto>();
        return products.Select(c => new ProducDto
        {
            Name = c.Name,
            Price = c.Price
        });
        
    }

}