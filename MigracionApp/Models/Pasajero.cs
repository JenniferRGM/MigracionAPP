using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigracionApp.Models
{
    public class Pasajero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string CorreoElectronico { get; set; }

        // Relaciones
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}