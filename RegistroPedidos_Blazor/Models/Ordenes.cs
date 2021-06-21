
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidos_Blazor.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        public DateTime Fecha {get; set; }

        public int SuplidorId { get; set; }

        [Range(minimum: 0.0, maximum: 10000000.0, ErrorMessage = "Inserte un monto válido")]
        public Decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public List<OrdenesDetalle> Detalle { get; set; } = new List<OrdenesDetalle>();
    }
}
