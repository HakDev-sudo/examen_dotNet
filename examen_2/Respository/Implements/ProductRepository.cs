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
}