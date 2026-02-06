using Infraestructura;
using Infraestructura.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Alumnos.Queries
{
    public class AlumnoCommandHandler
    {
        private readonly IConfiguration _configuration;

        public AlumnoCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Personas Handle(AlumnoCommand command)
        {
            List<Personas> alumnos = new List<Personas>();
            AlumnoDAO alumnoDAO = new AlumnoDAO(_configuration);
            Personas per = new Personas
            {
                Nombre = command.Nombre,
                ApellidoPaterno = command.ApellidoPaterno,
                ApellidoMaterno = command.ApellidoMaterno,
                FechaNacimiento = command.FechaNacimiento,
                CURP = command.CURP,
                TipoPersonaID = command.TipoPersonaID,
                GeneroID = command.GeneroID
            };
            Personas per2 = new Personas();
            per2 =alumnoDAO.InsertarAlumnos(per);
            return per2;
        }
    }
}
