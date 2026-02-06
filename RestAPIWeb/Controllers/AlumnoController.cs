using Aplicacion.Alumnos.Queries;
using Infraestructura.Entidades;
using Microsoft.AspNetCore.Mvc;
using RestAPIWeb.Controllers;

namespace RestAPI.Controllers
{
    public class AlumnoController : Controller
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CatalogosController> _logger;

        private IConfiguration configuration;

        public AlumnoController(ILogger<CatalogosController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ("Alumno/Crear")]
        public IActionResult Crear([FromBody] AlumnoCommand command)
        {
            Personas per = new Personas();
            AlumnoCommandHandler alcommhan = new AlumnoCommandHandler(configuration);
           per = alcommhan.Handle(command);
            if (per.ID == 0)
            {
                return BadRequest("Error al insertar el alumno");
            }
            return Created("https://localhost:7004/1", new {id = 1, name = "Registro Exitoso!"});


        }
        
           
        
    }
}
