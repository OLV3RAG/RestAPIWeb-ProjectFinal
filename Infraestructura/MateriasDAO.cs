using Infraestructura.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class MateriasDAO
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public MateriasDAO()
        {
        } 

        public MateriasDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Materias> ObtenerMaterias()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Materias> materias = new List<Materias>();
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ConsultarMaterias";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Materias materia = new Materias();
                        materia.ID = reader.GetInt32(0);
                        materia.Nombre = reader.GetString(1);
                        materias.Add(materia);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las materias: " + ex.Message);
            }
            return materias;
        }
    }
}

