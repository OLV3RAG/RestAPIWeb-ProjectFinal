using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Entidades
{
    public class Colonias
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int MunicipioID { get; set; }
        public int CodPostal { get; set; }
    }
}
