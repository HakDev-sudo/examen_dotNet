using examen_2.Models;
using examen_2.Respository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace examen_2.Respository.Implements;

public class ProductRepository: GenericRepository<Product>, IProductRepositoy
{
    public ProductRepository(ContextDbTienda  context) :  base(context)
    {
        
    }

    public async Task<IEnumerable<Product>>  ObtenerProductorMayorQue(decimal price)
    {
        var  products =   await   _context.Products.Where(p => p.Price > price).ToListAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Productid}, Nombre: {product.Name}, Precio: {product.Price}");
        }
        return await _context.Products.Where(p => p.Price > price).ToListAsync();
    }

    public async Task<IEnumerable<Product>> FilterProducByOrderId(int orderId)
    {
        return await _context.Orderdetails.Where(p => p.Orderid == orderId).Select(po => po.Product).ToListAsync();
    }

    public async Task<int> GetTatalQuntityOrderIdAsyn(int orderId)
    {
        // Ejercicio 4: Sumar las cantidades de los detalles de una orden
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }
    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        // Ejercicio 5: Obtener el producto con mayor precio
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Orderdetail>> GetAllOrderDetailsAsync()
    {
        // Ejercicio 10: obtener todos los detalles de pedidos
        return await _context.Orderdetails
            .Include(od => od.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        // Ejercicio 8: productos sin descripción
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        // Ejercicio 7: promedio de precio
        return await _context.Products
            .Select(p => p.Price)
            .AverageAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId)
    {
        // Ejercicio 11: productos vendidos a un cliente específico
        return await _context.Orders
            .Where(o => o.Clientid == clientId)
            .SelectMany(o => o.Orderdetails)
            .Select(od => od.Product)
            .Distinct()
            .ToListAsync();
    }
    
    
}