using Domain;
using Dominio.Entidades;
using Infraestructura;
using Infraestructura.AccesoBD;
using Infraestructura.Entidades;
using Infraestructura.Generos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Bson;
using System.IO; // Asegura que System.IO esté presente

namespace UnitTest
{
    public class Tests
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
        public void Test1()
        {
            Assert.Pass();
        }



        [Test]
        public void AbrirConexion_ConexionAbierta()
        {
            BaseDbConfig accesoBD = new BaseDbConfig(_configuration);

            var conn = accesoBD.ObtenerConexion();
            var result = accesoBD.OpenConnection(conn);

            Assert.AreEqual(System.Data.ConnectionState.Open, result);
        }

        //[Test]
        //public void ObtenerGeneros_NoTraeLosGeneros()
        //{
        //    List<Genero> gen = new List<Genero>();
        //    Generos generos = new Generos(_configuration);
        //    gen = generos.ObtenerGenero();

        //    Assert.IsEmpty(gen);
        //}

        [Test]
        public void ObtenerGeneros_TraeLosGeneros()
        {
            List<Genero> gen = new List<Genero>();
            GenerosDAO generos = new GenerosDAO(_configuration);
            gen = generos.ObtenerGenero();


            Assert.IsNotEmpty(gen);
        }

        [Test]
        public void ObtenerTipoPersona_TodosLosTiposPersona()
        {
            List<TipoPersona> tiposPersona = new List<TipoPersona>();
            TipoPersonasDAO tipoPersonas = new TipoPersonasDAO(_configuration);
            tiposPersona = tipoPersonas.ObtenerTipoPersona();
            Assert.IsNotEmpty(tiposPersona);

        }
        [Test]
        public void ObtenerMaterias_TodasLasMaterias()
        {
            List<Materias> materias = new List<Materias>();
            MateriasDAO materiasDAO = new MateriasDAO(_configuration);
            materias = materiasDAO.ObtenerMaterias();
            Assert.IsNotEmpty(materias);

        }

        [Test]
        public void ObtenerPersonaMaterias_TodasLasPersonaMaterias()
        {
            List<PersonaMateria> permat = new List<PersonaMateria>();
            PersonaMateriasDAO permatDAO = new PersonaMateriasDAO(_configuration);
            permat = permatDAO.ObtenerPersonaMaterias();
            Assert.IsNotEmpty(permat);
        }

        [Test]
        public void ObtenerTablaEdos_ObtenerTodosLosEdos()
        {
            List<Estados> estados = new List<Estados>();
            Localidades estadosDAO = new Localidades(_configuration);
            estados = estadosDAO.ObtenerEstados();
            Assert.IsNotEmpty(estados);
        }

        [Test]
        public void ObtenerTablaMpos_ObtenerTodosLosMpos()
        {
            List<Municipios> municipios = new List<Municipios>();
            Localidades municipiosDAO = new Localidades(_configuration);
            municipios = municipiosDAO.ObtenerMunicipios();
            Assert.IsNotEmpty(municipios);

        }

        [Test]
        public void ObtenerTablaCol_ObtenerTodasLasCol()
        {
            List<Colonias> colonias = new List<Colonias>();
            Localidades coloniasDAO = new Localidades(_configuration);
            colonias = coloniasDAO.ObtenerColonias();
            Assert.IsNotEmpty(colonias);
        }

        public void ObtenerMpos_PorEstadoID()
        {
            int estadoID = 1; // Ejemplo de EstadoID
            List<Municipios> municipios = new List<Municipios>();
            Localidades municipiosDAO = new Localidades(_configuration);
            municipios = municipiosDAO.ObtenerMunicipiosPorEstado(estadoID);
            Assert.IsNotEmpty(municipios);
        }



        [Test]
        public void ObtenerCol_PorMunicipioID()
        {
            int municipioID = 2458;
            List<Colonias> colonias = new List<Colonias>();
            Localidades coloniasDAO = new Localidades(_configuration);
            colonias = coloniasDAO.ObtenerColoniasPorMunicipio(municipioID);
            Assert.IsNotEmpty(colonias);
        }

        [Test]
        public void ObtenerMunicipiosPorEstado_Valido()
        {
        
            int estadoID = 13; 
            Localidades localidadesDAO = new Localidades(_configuration);
            List<Municipios> municipios = localidadesDAO.ObtenerMunicipiosPorEstado(estadoID);
            Assert.IsNotEmpty(municipios, "La lista de municipios no debería estar vacía para un estado válido.");
        }
        [Test]
        public void ObtenerCPporColonia_Valido()
        {
            int coloniaID = 42987;
            Localidades localidadesDAO = new Localidades(_configuration);
            List<Colonias> codigoPostal = localidadesDAO.ObtenerCodigosPostalesPorColonia(coloniaID);
            Assert.IsNotEmpty(codigoPostal);

        }
         
        [Test]
        public void ObtenerCPporColonia_Invalido()
        {
            int coloniaID = 42985;
            Localidades localidadesDAO = new Localidades(_configuration);
            EjemploLoc ejLoc = new EjemploLoc();
            List<Municipios> municipios = new List<Municipios>();
            List<Colonias> codigoPostal = localidadesDAO.ObtenerCodigosPostalesPorColonia(coloniaID);
            municipios = localidadesDAO.ObtenerMunicipios();

            Municipios municipio = municipios.Find(m => m.ID == codigoPostal[0].MunicipioID);
            Estados estados = localidadesDAO.ObtenerEstados().Find(e => e.ID == municipio.EstadoID);


            ejLoc.colonias = codigoPostal;
            ejLoc.municipio = municipio;
            ejLoc.estado = estados;


       

            Ejemplo ejemplo = new Ejemplo();
            ejemplo.Nombre = "Juan Perez";
            ejemplo.Salon = "A1";
            ejemplo.Materia = new List<Materias>
            {
                new Materias { ID = 1, Nombre = "Matemáticas" },
                new Materias { ID = 2, Nombre = "Historia" }
            };
            ejemplo.Direccion = new Direcciones
            {
                Calle = "Calle Falsa 123",
                Numero = 6,
                ColoniaID = 1,
                MunicipioID = 2,
                EstadoID = 3
            };
            ejemplo.Emails = new List<string> { "balbalba46@yahoo.com", "lolololo@gmail.com"};
            ejemplo.Telefono = "555-1234";
            string jsonEjem = System.Text.Json.JsonSerializer.Serialize(ejemplo);
            string jsonP = @"{'Nombre':'Juan Perez','Salon':'A1','Materia':[{'ID':1,'Nombre':'Matematicas'},{'ID':2,'Nombre':'Historia'}],'Direccion':{'ID':0,'ColoniaID':1,'MunicipioID':2,'EstadoID':3},'Emails':['balbalba46@yahoo.com','lolololo@gmail.com'],'Telefono':'555-1234'}";

            var objEjem = System.Text.Json.JsonSerializer.Deserialize<Ejemplo>(jsonP);
            string jsonLoca = System.Text.Json.JsonSerializer.Serialize(ejLoc);


            Assert.AreEqual(42985, codigoPostal[0].ID);
            Assert.IsNotNull(ejLoc.municipio);
        }

    }
}