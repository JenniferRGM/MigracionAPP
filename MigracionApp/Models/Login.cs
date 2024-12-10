using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigracionApp.Models
{
    public class Login
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public DateTime? UltimoAcceso { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; }
    }
}