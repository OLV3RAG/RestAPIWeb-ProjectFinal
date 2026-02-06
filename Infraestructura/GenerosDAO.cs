using Infraestructura.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestructura.Generos
{
    public class GenerosDAO
    {
        private readonly string _connectionString;
        public GenerosDAO()
        {
        }  
        public GenerosDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Genero> ObtenerGenero()
            {


            SqlConnection conn = new SqlConnection(_connectionString);
            List<Genero> generos = new List<Genero>();

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ConsultarGeneros";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Genero genero = new Genero();
                        genero.ID = reader.GetInt32(0);
                        genero.Descripcion = reader.GetString(1);
                        generos.Add(genero);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los géneros: " + ex.Message);
            }
            return generos;
        }


    }
}
