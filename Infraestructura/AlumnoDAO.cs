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
    public class AlumnoDAO
    {
        private readonly string _connectionString;

        public AlumnoDAO()
        {
        }
        public AlumnoDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Personas InsertarAlumnos(Personas per)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Personas> alumnos = new List<Personas>();

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_InsertarPersonas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", per.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", per.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno",per.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", per.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", per.CURP);
                    cmd.Parameters.AddWithValue("@TipoPersonaID", per.TipoPersonaID);
                    cmd.Parameters.AddWithValue("@GeneroID", per.GeneroID);

                    SqlParameter 
                        outputIdParam = new SqlParameter("@NuevoID", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    cmd.ExecuteNonQuery();
                    if (outputIdParam.Value != DBNull.Value)
                    {
                        per.ID = Convert.ToInt32(outputIdParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                return per;
            }

            return per;
        }
    }
}
