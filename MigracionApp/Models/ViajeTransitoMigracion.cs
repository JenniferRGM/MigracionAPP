using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigracionApp.Models
{
    public class ViajeTransitoMigracion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Destino { get; set; }
        public string Origen { get; set; }
        public string TipoSolicitud { get; set; }
        public string MotivoViaje { get; set; }

        // Relaciones
        public int PasajeroId { get; set; }
        public Pasajero Pasajero { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}