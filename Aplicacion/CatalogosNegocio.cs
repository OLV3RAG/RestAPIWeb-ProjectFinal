using Infraestructura;
using Infraestructura.Entidades;
using Infraestructura.Generos;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Aplicacion
{
    public class CatalogoNegocio
    {
        private readonly IConfiguration _configuration;

        public CatalogoNegocio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Genero> ObtenerCatalogoGen()
        {
            List<Genero> gene = new List<Genero>();
            GenerosDAO genDao = new GenerosDAO(_configuration);
            gene = genDao.ObtenerGenero();
            return gene;
        }
        public List<Materias> ObtenerCatalogoMat()
        {
            List<Materias> listaMaterias = new List<Materias>();
            MateriasDAO matDao = new MateriasDAO(_configuration);
           listaMaterias = matDao.ObtenerMaterias();
            return listaMaterias;
        }
        public List<TipoPersona> ObtenerCatalogoTipPer()
        {
            List<TipoPersona> tipPer = new List<TipoPersona>();
            TipoPersonasDAO tipPerDao = new TipoPersonasDAO(_configuration);
            tipPer = tipPerDao.ObtenerTipoPersona();
            return tipPer;
        }

        public List<Estados> ObtenerCatalogoEstados()
        {
            List<Estados> estados = new List<Estados>();
            Localidades loc = new Localidades(_configuration);
            estados = loc.ObtenerEstados();
            return estados;
        }

        public List<Colonias> ObtenerCatalogoColonias()
        {
            List<Colonias> colonias = new List<Colonias>();
            Localidades loc = new Localidades(_configuration);
            colonias = loc.ObtenerColonias();
            return colonias;
        }

      public List<Municipios> ObtenerCatalogoMunicipios()
        {
            List<Municipios> municipios = new List<Municipios>();
            Localidades loc = new Localidades(_configuration);
            municipios = loc.ObtenerMunicipios();
            return municipios;
        }

        public List<Colonias> ObtenerColoniasPorMunicipio(int municipioId)
        {
            List<Colonias> colonias = new List<Colonias>();
            Localidades loc = new Localidades(_configuration);
            colonias = loc.ObtenerColoniasPorMunicipio(municipioId);
            return colonias;
        }

        public List<Colonias> ObtenerCPxColonia(int coloniaID)
        {
            List<Colonias> colonias = new List<Colonias>();
            Localidades loc = new Localidades(_configuration);
            colonias = loc.ObtenerCodigosPostalesPorColonia(coloniaID);
            return colonias;
        }

        public List<Municipios> ObtenerMposxEstado(int estadoID)
        {
            List<Municipios> municipios = new List<Municipios>();
            Localidades loc = new Localidades(_configuration);
            municipios = loc.ObtenerMunicipiosPorEstado(estadoID);
            return municipios;
        }
    }
}
