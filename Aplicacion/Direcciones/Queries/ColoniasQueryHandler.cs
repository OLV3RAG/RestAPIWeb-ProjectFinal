using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Direcciones.Queries
{
    public class ColoniasQueryHandler
    {
        private readonly IConfiguration _configuration;

        public ColoniasQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ColoniasQuery> Handle(int municipioID)
        {
            List<Infraestructura.Entidades.Colonias> colonias = new List<Infraestructura.Entidades.Colonias>();
            Infraestructura.Localidades loc = new Infraestructura.Localidades(_configuration);
            colonias = loc.ObtenerColoniasPorMunicipio(municipioID);
            List<ColoniasQuery> coloniaQueries = new List<ColoniasQuery>();
            foreach (var colonia in colonias)
            {
                coloniaQueries.Add(new ColoniasQuery
                {
                    ID = colonia.ID,
                    Nombre = colonia.Nombre,
                    Descripcion = colonia.Descripcion,
                    CodPostal = colonia.CodPostal
                });
            }
            return coloniaQueries;
        }
    }
}
