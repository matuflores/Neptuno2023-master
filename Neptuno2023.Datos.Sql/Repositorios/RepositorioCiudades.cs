using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Sql.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {
        private string cadenaDeConexion;
        public RepositorioCiudades()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public void Editar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }
        
        public int GetCantidad()
        {
            int cantidad = 0;
            using (var _conn=new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Ciudades";
                using (var comando=new SqlCommand(selectQuery,_conn))
                {
                    cantidad=Convert.ToInt32(comando.ExecuteScalar());//
                }

            }
            return cantidad;
        }

        public List<Ciudad> GetCiudades()
        {//hago que me traiga las ciudades
            try
            {
                List<Ciudad> lista=new List<Ciudad>();
                using (var _conn = new SqlConnection(cadenaDeConexion))
                {
                    _conn.Open();
                    string selectQuery = "SELECT CiudadId, PaisId, NombreCiudad FROM Ciudades ORDER BY PaisId, NombreCiudad";
                    using (var comando=new SqlCommand(selectQuery,_conn))//los parametros del command deben ir en este orden
                    {
                        using (var reader=comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ciudad = new Ciudad()
                                {
                                    CiudadId = reader.GetInt32(0),//leo la primer columna en sql
                                    PaisId = reader.GetInt32(1),//leo la segunda columna 
                                    NombreCiudad=reader.GetString(2)
                                };
                                lista.Add(ciudad);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
