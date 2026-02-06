using Infraestructura;
using Infraestructura.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Direcciones.Queries
{
    public class EstadosQueryHandler
    {
        private readonly IConfiguration _configuration;

        public EstadosQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<EstadoQuery> Handle()
        { 
            List<Estados> edos = new List<Estados>();
            Localidades loc = new Localidades(_configuration);
            edos = loc.ObtenerEstados();
            List<EstadoQuery> edoQuery = new List<EstadoQuery>();
            foreach (var edo in edos)
            {
                edoQuery.Add(new EstadoQuery
                {
                    ID = edo.ID,
                    Descripcion = edo.Nombre

                });
            }
            return edoQuery;
        }

    }
}
