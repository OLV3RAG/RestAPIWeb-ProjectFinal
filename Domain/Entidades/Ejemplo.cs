using Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Ejemplo
    {
        public string Nombre { get; set; }
        public string Salon { get; set; }
        public List<Materias> Materia { get; set; }
        public Direcciones Direccion { get; set; }
        public List<string> Emails { get; set; }
        public string Telefono { get; set; }
    }
}
