using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Alumnos.Queries
{
    public class AlumnoCommand
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public int TipoPersonaID { get; set; }
        public int GeneroID { get; set; }
    }
}
