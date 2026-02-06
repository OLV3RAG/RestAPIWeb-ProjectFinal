using Infraestructura.AccesoBD;
using Infraestructura.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestructura
{
    public class PersonaMateriasDAO : BaseDbConfig
    {
        private readonly string _connectionString;
        public PersonaMateriasDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<PersonaMateria> ObtenerPersonaMaterias()
        {
            SqlConnection conn = new SqlConnection();
            List<PersonaMateria> permat = new List<PersonaMateria>();
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ConsultarPersonaMaterias";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PersonaMateria personaMateria = new PersonaMateria();
                        personaMateria.PersonaID = reader.GetInt32(0);
                        personaMateria.MateriaID = reader.GetInt32(1);
                        permat.Add(personaMateria);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return permat;
           
        }
    }
}
