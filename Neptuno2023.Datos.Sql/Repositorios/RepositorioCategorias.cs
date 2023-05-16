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

namespace Neptuno2023.Datos.Sql.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        //tiene que comusinarse con la BD por lo tanto debe saber donde estan los datos, eso me lo da la cadena de conexion
        private string cadenaDeConexion;
        public RepositorioCategorias()
        {//cuando instancio el repositorio se habre la conexion dde la sigueinte manera:
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        //proyecto de github
        public void Agregar(Categoria categoria)
        {
            using (var _conn=new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();
                var insertQuery = "INSERT INTO Categorias (NombreCategoria, Descripcion) VALUES (@NombreCategoria,@Descripcion); SELECT SCOPE_IDENTITY()";
                using (var comando=new SqlCommand(insertQuery,_conn))
                {
                    comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                    comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar);
                    comando.Parameters["@Descripcion"].Value = categoria.Descripcion;

                    int id=Convert.ToInt32(comando.ExecuteScalar());
                    categoria.CategoriaId = id;
                }
            }
        }

        public void Editar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetCategorias()//paso 6(clase 2)
        {//este metodo debe devolver una lista de categorias para eso creo una lista
            List<Categoria> lista = new List<Categoria>();
            using (var _conn=new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();//abro la conexion
                var selectQuery = "SELECT CategoriaId, NombreCategoria, Descripcion, RowVersion FROM Categorias";
                using (var comando=new SqlCommand(selectQuery, _conn))//creo el comanddo
                {
                    using (var reader=comando.ExecuteReader())//crel el atributo que va a leer luego le páso el comando con el atributo previamente creado
                    {
                        while (reader.Read())
                        {
                            var categoria = new Categoria()
                            {
                                CategoriaId = reader.GetInt32(0),
                                NombreCategoria = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                RowVersion= (byte[])reader[3]//no hay Get nos traiga un array de byte, por eso se castea
                            };
                            lista.Add(categoria);
                        }//cierro reader
                    }//cierro el comando
                }//cierro la conexion
                return lista;
            }
        }
    }
}
