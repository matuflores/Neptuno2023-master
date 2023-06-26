using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            using (var _conn = new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();//abro la conexion //
                var insertQuery = "INSERT INTO Ciudades (NombreCiudad, PaisId) VALUES (@NombreCiudad, @PaisId); SELECT SCOPE_IDENTITY()";//esta es la "cadena de comanddo" y lo que hace es insertar el Pais y me devuelve el id que acaba de generar.-cuando hago un insert solo le paso los datos que no se generan automaticamen, es ddecir el id y la rowversion no es necesario porq se generan solo
                using (var comando = new SqlCommand(insertQuery, _conn)) //aca creo el comando                                            /select scope_identity() me traigo el indice
                {//en insert paso parametros que tengo que ddefinir
                    comando.Parameters.Add("@NombreCiudad", SqlDbType.NVarChar);//aca ddigo te voy pasar un parametro que se llama nombre pais y que es tipo nvarchar
                    comando.Parameters["@NombreCiudad"].Value = ciudad.NombreCiudad;//primero defini el nombre y el tipo de dato que va a ser y aca le asigno el valor al parametro

                    comando.Parameters.Add("@PaisId", SqlDbType.Int);
                    comando.Parameters["@PaisId"].Value = ciudad.PaisId;

                    int id = Convert.ToInt32(comando.ExecuteScalar());//el ExecuteScalar devuelve un objeto y como lo que me va a traer a mis es el id y es de tipo entero lo tengo que castear
                    ciudad.CiudadId = id;//aca me traigo el id del nuevo pais que acabo de agregar/modifica*(8)
                }
            }
        }

        public void Borrar(int ciudadId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Ciudades WHERE CiudadId=@CiudadId";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@CiudadId", SqlDbType.Int);
                        comando.Parameters["@CiudadId"].Value = ciudadId;

                        comando.ExecuteNonQuery();//esto lo que hace es mandar el comando al Sql. Se usa para el borrar
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro relacionado... Baja Denegada");
                }
            }
        }

        public void Editar(Ciudad ciudad)
        {
            try
            {
                using (var _conn = new SqlConnection(cadenaDeConexion))//el bloque using se encarga de cerrar la conexion
                {
                    _conn.Open();//      
                    string updateQuery = "UPDATE Ciudades SET NombreCiudad=@NombreCiudad, PaisId=@PaisId WHERE CiudadId=@CiudadId";//paso comando de actualizar
                                                                                                         //los registros de una tabla tiene una clave principal y es la que uso para indicar que pais voy a actualizar
                    using (var comando = new SqlCommand(updateQuery, _conn))
                    {
                        comando.Parameters.Add("@NombreCiudad", SqlDbType.NChar);//
                        comando.Parameters["@NombreCiudad"].Value = ciudad.NombreCiudad;

                        comando.Parameters.Add("@PaisId", SqlDbType.Int);
                        comando.Parameters["@PaisId"].Value = ciudad.PaisId;

                        comando.Parameters.Add("@CiudadId",SqlDbType.Int);
                        comando.Parameters["@CiudadId"].Value = ciudad.CiudadId;

                        //ahora lo tengo que mandar para ejecutar y que actualice
                        comando.ExecuteNonQuery();//
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            int cantidad;
            using (var _conn=new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();
                string selectQuery;
                if (ciudad.CiudadId==0)
                {
                    selectQuery = "SELECT COUNT(*) FROM Ciudades WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId";
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Ciudades WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId AND CiudadId!=@CiudadId";
                }
                using (var comando=new SqlCommand(selectQuery,_conn))
                {
                    comando.Parameters.Add("@NombreCiudad", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCiudad"].Value = ciudad.NombreCiudad;

                    comando.Parameters.Add("@PaisId", SqlDbType.Int);
                    comando.Parameters["@PaisId"].Value = ciudad.PaisId;

                    if (ciudad.CiudadId!=0)
                    {
                        comando.Parameters.Add("@CiudadId", SqlDbType.Int);
                        comando.Parameters["@CiudadId"].Value=ciudad.CiudadId;
                    }
                    cantidad=Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            return cantidad > 0;
        }

        public List<Ciudad> Filtrar(Pais pais)
        {
            try
            {
                List<Ciudad> lista = new List<Ciudad>();
                using (var _conn = new SqlConnection(cadenaDeConexion))
                {
                    _conn.Open();
                    string selectQuery = "SELECT CiudadId, PaisId, NombreCiudad FROM Ciudades WHERE PaisId=@PaisId ORDER BY PaisId, NombreCiudad";
                    using (var comando = new SqlCommand(selectQuery, _conn))//los parametros del command deben ir en este orden
                    {
                        comando.Parameters.Add("@PaisId", SqlDbType.Int);
                        comando.Parameters["@PaisId"].Value = pais.PaisId;

                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ciudad = ConstruirCiudad(reader);
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
                                var ciudad = ConstruirCiudad(reader);
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

        public List<Ciudad> GetCiudadesPorPagina(int cantidad, int paginaActual)
        {
            try
            {
                List<Ciudad> lista = new List<Ciudad>();
                using (var _conn = new SqlConnection(cadenaDeConexion))
                {
                    _conn.Open();
                    string selectQuery = @"SELECT CiudadId, PaisId, NombreCiudad FROM Ciudades 
                                            ORDER BY PaisId, NombreCiudad 
                                            OFFSET @cantidadDeRegistros ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    using (var comando = new SqlCommand(selectQuery, _conn))//los parametros del command deben ir en este orden
                    {
                        comando.Parameters.Add("@cantidadDeRegistros", SqlDbType.Int);
                        comando.Parameters["@cantidadDeRegistros"].Value = cantidad * (paginaActual - 1);//para que no me salte ningun registro hago la cuenta esa

                        comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                        comando.Parameters["@cantidadPorPagina"].Value = cantidad;
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ciudad = ConstruirCiudad(reader);
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

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            
            
                Ciudad ciudad = null;
                using (var _conn = new SqlConnection(cadenaDeConexion))
                {
                    _conn.Open();
                    string selectQuery = "SELECT CiudadId, NombreCiudad FROM Ciudades WHERE CiudadId=@CiudadId";
                    using (var comando = new SqlCommand(selectQuery, _conn))//los parametros del command deben ir en este orden
                    {
                        comando.Parameters.Add("@CiudadId", SqlDbType.Int);
                        comando.Parameters["@CiudadId"].Value=ciudadId;

                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                ciudad=ConstruirCiudadId(reader);
                            }
                        }
                    }
                }
                return ciudad;
            
        }

        public Ciudad ConstruirCiudadId(SqlDataReader reader)
        {
            return new Ciudad()
            {
                CiudadId = reader.GetInt32(0),
                NombreCiudad = reader.GetString(1),
            };
        }

        public Ciudad ConstruirCiudad(SqlDataReader reader)
        {
            return new Ciudad()
            {
                CiudadId = reader.GetInt32(0),
                PaisId = reader.GetInt32(1),
                NombreCiudad = reader.GetString(2),
            };
        }
    }
}
