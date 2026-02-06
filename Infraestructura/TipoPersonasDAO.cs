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
    public class TipoPersonasDAO
    {
        private readonly string _connectionString;
       
        public TipoPersonasDAO()
        {
        }   

        public TipoPersonasDAO(IConfiguration configuration)
        {
             _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<TipoPersona> ObtenerTipoPersona()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<TipoPersona> tiposPersona = new List<TipoPersona>();
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ConsultarTipoPersonas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoPersona tipoPersona = new TipoPersona();
                        tipoPersona.ID = reader.GetInt32(0);
                        tipoPersona.Descripcion = reader.GetString(1);
                        tiposPersona.Add(tipoPersona);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los tipos de persona: " + ex.Message);
            }
            return tiposPersona;
        }
    }
}
