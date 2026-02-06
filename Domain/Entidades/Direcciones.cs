using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Entidades
{
    public class Direcciones
    {
        public int ID { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int ColoniaID { get; set; }
        public int MunicipioID { get; set; }
        public int EstadoID { get; set; }
    }
}
