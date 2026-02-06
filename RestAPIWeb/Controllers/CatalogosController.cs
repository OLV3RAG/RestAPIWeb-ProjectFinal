using Aplicacion;
using Aplicacion.Direcciones.Queries;
using Infraestructura;
using Infraestructura.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace RestAPIWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CatalogosController> _logger;

        private IConfiguration configuration;

        public CatalogosController(ILogger<CatalogosController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ObtenerMaterias")]
        public List<Materias> ObtenerMaterias()
        {
            List<Materias> listaMaterias = new List<Materias>();
            CatalogoNegocio catNeg = new CatalogoNegocio(configuration);
            listaMaterias = catNeg.ObtenerCatalogoMat();
            return listaMaterias;
        }
        [HttpGet("ObtenerGenerosAlumnos")]
        public List<Genero> ObtenerGenerosdeAlumnos()
        {
            List<Genero> gen = new List<Genero>();
            CatalogoNegocio catNeg = new CatalogoNegocio(configuration);
            gen = catNeg.ObtenerCatalogoGen();
            return gen;
        }
        [HttpGet("ObtenerTipoPersonas")]
        public List<TipoPersona> ObtenerTipoPersonas()
        {
            List<TipoPersona> tipPer = new List<TipoPersona>();
            CatalogoNegocio catNeg = new CatalogoNegocio(configuration);
            tipPer = catNeg.ObtenerCatalogoTipPer();
            return tipPer;

        }

        [HttpGet("ObtenerEstados")]
        public List<EstadoQuery> ObtenerEstados()
        {
            List<EstadoQuery> edoQuery = new List<EstadoQuery>();
            EstadosQueryHandler edosQryHnd = new EstadosQueryHandler(configuration);
            edoQuery = edosQryHnd.Handle();
            return edoQuery;
        }
        [HttpGet("ObtenerColonias")]
        public List<Colonias> ObtenerColonias()
        {
            List<Colonias> col = new List<Colonias>();
            CatalogoNegocio catNeg = new CatalogoNegocio(configuration);
            col = catNeg.ObtenerCatalogoColonias();
            return col;
        }
        [HttpGet("ObtenerMunicipios")]
        public List<Municipios> ObtenerMunicipios()
        {
            List<Municipios> mpos = new List<Municipios>();
            CatalogoNegocio catNeg = new CatalogoNegocio(configuration);
            mpos = catNeg.ObtenerCatalogoMunicipios();
            return mpos ;
        }

        [HttpGet("ObtenerColporMpo")]
        public List<ColoniasQuery> ObtenerColporMpo(int municipioID)
        {
            List<ColoniasQuery> colQuery = new List<ColoniasQuery>();
            ColoniasQueryHandler colQryHnd = new ColoniasQueryHandler(configuration);
            colQuery = colQryHnd.Handle(municipioID);
            return colQuery;
        }

        [HttpGet("ObtenerCPxMpo")]
        public List<Colonias> ObtenerCPxMpo(int coloniaID)
        {
            List<Colonias> codigosPostales = new List<Colonias>();
            CatalogoNegocio catNeg = new CatalogoNegocio(configuration);
            codigosPostales = catNeg.ObtenerCPxColonia(coloniaID);
            return codigosPostales;
        }

        [HttpGet("ObtenerMposxEdos")]

        public List<MunicipioQuery> ObtenerMposxEdos(int estadoID)
        {
            List<MunicipioQuery> mpos = new List<MunicipioQuery>();
            MunicipioQueryHandler mpoqhand = new MunicipioQueryHandler(configuration);
            mpos = mpoqhand.Handle(estadoID);
            return mpos;
        }
    }
}
