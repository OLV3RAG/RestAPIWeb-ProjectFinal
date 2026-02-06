using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Infraestructura.AccesoBD
{
    public class BaseDbConfig
    {
        private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;
        public BaseDbConfig()
        {

        }

        public BaseDbConfig(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }

        public ConnectionState OpenConnection(SqlConnection connection)
        {
            ConnectionState estatusConexion;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                estatusConexion = connection.State;
               return estatusConexion;
            }

            return ConnectionState.Closed; 
        }

        //ObtenerEstados();
        //ObtenerTipoPersona();
        //ObtenerPersonaMateria();
        //ObtenerMaterias();
        //ObtenerMunicipios();
        //ObtenerColonias();
    }
}
