using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MigracionApp.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}