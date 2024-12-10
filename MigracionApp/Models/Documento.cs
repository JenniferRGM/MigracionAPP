using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigracionApp.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaExpiracion { get; set; }

        // Relaciones
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public int PasajeroId { get; set; }
        public Pasajero Pasajero { get; set; }
    }
}