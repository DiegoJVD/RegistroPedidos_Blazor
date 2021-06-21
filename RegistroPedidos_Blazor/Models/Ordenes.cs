
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroPedidos_Blazor.Models
{
    public class Ordenes
    {
        public int OrdenId { get; set; }

        public DateTime Fecha {get; set; }

        public int SuplidorId { get; set; }

        [Range(minimum: 0.0, maximum: 10000000.0, ErrorMessage = "Inserte un monto válido")]
        public Decimal Monto { get; set; }
    }
}
