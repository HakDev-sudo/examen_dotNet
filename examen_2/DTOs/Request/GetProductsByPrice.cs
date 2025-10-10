using System.ComponentModel.DataAnnotations;

namespace examen_2.DTOs.Request;

public class GetProductsByPrice
{
    [Required]
    public decimal Price { get; set; }
}