using Infraestructura;
using Infraestructura.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PruebasIntegracion
    {
        protected IConfiguration _configuration;
        protected string _cadenaConexion;

        [SetUp] // Se ejecuta antes de cada test
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Apunta a bin/Debug/net...
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
            _cadenaConexion = _configuration.GetConnectionString("CadenaSQL");
        }

        [Test]
        public void PruebaDeIntegracionEjemplo()
        {
            List<Estados> estados = new List<Estados>();
            Localidades localidadesDAO = new Localidades(_configuration);
            estados = localidadesDAO.ObtenerEstados();

            var estado = estados.FirstOrDefault(e => e.Nombre == "Hidalgo");
            
            List<Municipios> municipios = new List<Municipios>();
            municipios = localidadesDAO.ObtenerMunicipiosPorEstado(estado.ID);
            var municipio = municipios.FirstOrDefault(m => m.Nombre == "Atotonilco de Tula");

            List<Colonias> colonias = new List<Colonias>();
            colonias = localidadesDAO.ObtenerColoniasPorMunicipio(municipio.ID);

            Assert.IsTrue(colonias.Any(colonias => colonias.Nombre == "Progreso"));

        }




    }
}
