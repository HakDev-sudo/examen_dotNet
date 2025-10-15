using examen_2.Application.DTOs.Response;
using examen_2.Application.Interfaces;
using examen_2.Domain.Interfaces;
using examen_2.Domain.Entities;

namespace examen_2.Application.Services;

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

    public async Task<QuantityByOrderDto> GetTotalQuantityByOrderId(int orderId)
    {
        var total = await _unitOfWork.Products.GetTatalQuntityOrderIdAsyn(orderId);
        return new QuantityByOrderDto { OrderId = orderId, TotalQuantity = total };
    }

    public async Task<ProducDto?> GetMostExpensiveProduct()
    {
        var p = await _unitOfWork.Products.GetMostExpensiveProductAsync();
        if (p == null) return null;
        return new ProducDto { Name = p.Name, Price = p.Price };
    }

    public async Task<IEnumerable<Orderdetail>> GetAllOrderDetails()
    {
        return await _unitOfWork.Products.GetAllOrderDetailsAsync();
    }

    public async Task<decimal> GetAveragePrice()
    {
        return await _unitOfWork.Products.GetAveragePriceAsync();
    }

    public async Task<IEnumerable<ProductQuantityDto>> GetOrderDetailsProductQuantity()
    {
        var details = await _unitOfWork.Products.GetAllOrderDetailsAsync();
        return details.Select(d => new ProductQuantityDto
        {
            ProductName = d.Product.Name,
            Quantity = d.Quantity
        });
    }

    public async Task<IEnumerable<Product>> GetProductsWithoutDescription()
    {
        return await _unitOfWork.Products.GetProductsWithoutDescriptionAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsSoldToClient(int clientId)
    {
        return await _unitOfWork.Products.GetProductsSoldToClientAsync(clientId);
    }

    public async Task<IEnumerable<ClientOrdersCountDto>> GetClientWithMostOrders()
    {
        var groups = await _unitOfWork.Repository<Order>().GetAllAsync();
        // We'll compute groups from Orders dbset directly via unit of work context
        var orders = groups as IEnumerable<Order> ?? groups.ToList();
        var result = orders
            .GroupBy(o => o.Clientid)
            .Select(g => new ClientOrdersCountDto
            {
                ClientId = g.Key,
                ClientName = g.First().Client?.Name ?? string.Empty,
                OrdersCount = g.Count()
            })
            .OrderByDescending(x => x.OrdersCount)
            .ToList();

        return result;
    }

    public async Task<IEnumerable<string>> GetClientsWhoBoughtProduct(int productId)
    {
        var clients = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();
        var names = clients
            .Where(od => od.Productid == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct();
        return names;
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDate(DateTime date)
    {
        var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
        return orders.Where(o => o.Orderdate > date).ToList();
    }
}