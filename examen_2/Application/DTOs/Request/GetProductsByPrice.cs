using System.ComponentModel.DataAnnotations;

namespace examen_2.Application.DTOs.Request;

public class GetProductsByPrice
{
    [Required]
    public decimal Price { get; set; }
}