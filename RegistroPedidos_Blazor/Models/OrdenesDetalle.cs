using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroPedidos_Blazor.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }


        public int OrdenId { get; set; }

        [Range(minimum: 0.0, maximum: 10000000.0, ErrorMessage = "La cantidad no es valida válido")]
        public double Cantidad { get; set; }

        [Range(minimum: 0.0, maximum: 50000000.0, ErrorMessage = "Inserte un costo válido")]
        public decimal Costo { get; set; }
    }
}
