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
    public class Localidades
    {
        private readonly string _connectionString;
        public Localidades()
        {
        }
        public Localidades(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Estados> ObtenerEstados()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Estados> estados = new List<Estados>();

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerEstados";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Estados estado = new Estados();
                        estado.ID = reader.GetInt32(0);
                        estado.Nombre = reader.GetString(1);
                        estados.Add(estado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estados: " + ex.Message);
            }
            return estados;
        }

        public List<Colonias> ObtenerColonias()
            {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Colonias> colonias = new List<Colonias>();

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerColonias";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Colonias colonia = new Colonias();
                        colonia.ID = reader.GetInt32(0);
                        colonia.Nombre = reader.GetString(1);
                        colonia.Descripcion = reader.GetString(2);
                        colonia.MunicipioID = reader.GetInt32(3);
                        colonia.CodPostal = reader.GetInt32(4);
                        colonias.Add(colonia);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las colonias: " + ex.Message);
            }
            return colonias;
        }

        public List<Municipios> ObtenerMunicipios()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Municipios> mpos = new List<Municipios>();
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerMunicipios";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Municipios mposi = new Municipios();
                        mposi.ID = reader.GetInt32(0);
                        mposi.Nombre = reader.GetString(1);
                        mposi.EstadoID = reader.GetInt32(2);
                        mpos.Add(mposi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los municipios: " + ex.Message);
            }
            return mpos;
        }
        public List<Municipios> ObtenerMunicipiosPorEstado(int estadoID)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Municipios> MposxEdos = new List<Municipios>();
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerMunicipiosPorEstado";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EstadoID", estadoID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Municipios mposi = new Municipios();
                        mposi.ID = reader.GetInt32(0);
                        mposi.Nombre = reader.GetString(1);
                        mposi.EstadoID = reader.GetInt32(2);
                        MposxEdos.Add(mposi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los municipios por estado: " + ex.Message);
            }
            return MposxEdos;


        }
        public List<Colonias> ObtenerColoniasPorMunicipio(int municipioID)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            List<Colonias> ColxMpos = new List<Colonias>();

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerColoniasPorMunicipio";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MunicipioID", municipioID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Colonias colonia = new Colonias();
                        colonia.ID = reader.GetInt32(0);
                        colonia.Nombre = reader.GetString(1);
                        colonia.Descripcion = reader.GetString(2);
                        colonia.MunicipioID = reader.GetInt32(3);
                        colonia.CodPostal = reader.GetInt32(4);
                        ColxMpos.Add(colonia);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las colonias por municipio: " + ex.Message);
            }
            return ColxMpos;

        }

        public List<Colonias> ObtenerCodigosPostalesPorColonia(int coloniaID)
        {
            List<Colonias> codigosPostales = new List<Colonias>();
            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_ObtenerColoniasPorCodigoPostal";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodPostal", coloniaID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Colonias colonia = new Colonias();
                        colonia.ID = reader.GetInt32(0);
                        colonia.Nombre = reader.GetString(1);
                        colonia.Descripcion = reader.GetString(2);
                        colonia.MunicipioID = reader.GetInt32(3);
                        colonia.CodPostal = reader.GetInt32(4);
                        codigosPostales.Add(colonia);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los códigos postales por colonia: " + ex.Message);
            }
            return codigosPostales;
        }
    }
}
