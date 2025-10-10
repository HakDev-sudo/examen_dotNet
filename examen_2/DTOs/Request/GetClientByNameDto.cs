using System.ComponentModel.DataAnnotations;

namespace examen_2.DTOs.Request;

public class GetClientByNameDto
{
    [Required]
    public string Name { get; set; }
}