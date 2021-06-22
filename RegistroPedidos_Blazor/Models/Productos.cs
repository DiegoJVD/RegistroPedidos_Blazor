using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroPedidos_Blazor.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        
        [Required(ErrorMessage ="Es obligatorio introducir la descripción")]
        public string Descripcion { get; set; }

       [Range(minimum: 0.0, maximum: 10000000.0, ErrorMessage = "Inserte un costo válido")]
        public decimal Costo { get; set; }

        public float Inventario { get; set; }
    }
}
