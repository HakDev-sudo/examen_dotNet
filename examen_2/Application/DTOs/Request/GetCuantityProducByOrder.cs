using System.ComponentModel.DataAnnotations;

namespace examen_2.Application.DTOs.Request;

public class GetCuantityProducByOrder
{
   [Required] 
   public int Orderid { get; set; }
}