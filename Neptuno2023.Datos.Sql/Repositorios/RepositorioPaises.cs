﻿using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;//este instale (*1)
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Sql.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises //los repositorios son clases concretas porque implementan la interfaz
    {
        //private readonly IDbConnection _conn; //paso 5to: creo la cone //(*2)private readonly IDbConnection _conn;
        private string cadenaDeConexion; //
        public RepositorioPaises()//cuando se ejecuta el constructor va a leer la cadena de conexion (datos que escribi en el app.confing
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();//aca instale el using configuration (*1), en conecctionstring le pongo entre corchetes el nombre de mi cadena de conexion
        }//cuando se crea el repo va a buscar la cadena de conexion

        public void Borrar(int paisId)
        {
            try
            {
                using (var conn=new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Paises WHERE PaisId=@PaisId";
                    using (var comando=new SqlCommand(deleteQuery,conn))
                    {
                        comando.Parameters.Add("@PaisId", SqlDbType.Int);
                        comando.Parameters["@PaisId"].Value = paisId;

                        comando.ExecuteNonQuery();//esto lo que hace es mandar el comando al Sql. Se usa para el borrar
                    }

                }
            }
            catch (Exception) 
            {
                throw;
            }
        }
        
        public void Agregar(Pais pais)//(paso 10) aca implemente los dos nuevo metodos de la capa IRepositorioPaises(*4)
        {
            using (var _conn=new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();//abro la conexion
                var insertQuery = "INSERT INTO Paises (NombrePais) VALUES (@NombrePais); SELECT SCOPE_IDENTITY()";//esta es la "cadena de comanddo" y lo que hace es insertar el Pais y me devuelve el id que acaba de generar.-cuando hago un insert solo le paso los datos que no se generan automaticamen, es ddecir el id y la rowversion no es necesario porq se generan solo
                using (var comando = new SqlCommand(insertQuery, _conn)) //aca creo el comando
                {//en insert paso parametros que tengo que ddefinir
                    comando.Parameters.Add("@NombrePais", SqlDbType.NVarChar);//aca ddigo te voy pasar un parametro que se llama nombre pais y que es tipo nvarchar
                    comando.Parameters["@NombrePais"].Value = pais.NombrePais;//primero defini el nombre y el tipo de dato que va a ser y aca le asigno el valor al parametro

                    int id=Convert.ToInt32(comando.ExecuteScalar());//el ExecuteScalar devuelve un objeto y como lo que me va a traer a mis es el id y es de tipo entero lo tengo que castear
                    pais.PaisId = id;//aca me traigo el id del nuevo pais que acabo de agregar/modifica*(8)
                }
            }
        }

        public void Editar(Pais pais)
        {
            using (var _conn = new SqlConnection(cadenaDeConexion))
            {
                _conn.Open();
                string updateQuery = "UPDATE Paises SET NombrePais=@NombrePais WHERE PaisId=@PaisId";//paso comando de actualizar
                //los registros de una tabla tiene una clave principal y es la que uso para indicar que pais voy a actualizar
                using (var comando =new SqlCommand(updateQuery,_conn))
                {
                    using (var reader=comando.ExecuteReader())
                    {//tengo que pasar dos parametros (las variables que tienen el @)
                        comando.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
                        comando.Parameters["@NombrePais"].Value = pais.NombrePais;

                        comando.Parameters.Add("@PaisId", SqlDbType.Int);
                        comando.Parameters["@PaisId"].Value=pais.PaisId;
                        //ahora lo tengo que ejecutar
                        comando.ExecuteNonQuery();

                    }
                }
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                var contador = 0;
                using (var conn=new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Paises WHERE NombrePais=@NombrePais";//me tengo que fijar si existe el pais
                    using (var comando=new SqlCommand(selectQuery,conn))
                    {
                        comando.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
                        comando.Parameters["@NombrePais"].Value = pais.NombrePais;

                        contador=(int)comando.ExecuteScalar();
                    }
                }
                return contador > 0;//SI EL CONTADOR ES MAYOR A 0 ES PORQUE EL PAIS EXISTE
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {//tengo que preguntarle a la BD cuantos registros tengo
                int cantidad = 0;
                using (var conn=new SqlConnection(cadenaDeConexion))
                {
                    
                    conn.Open();
                    string selectQuery = "SELECT COUNT (*) FROM Paises";
                    using (var comando=new SqlCommand(selectQuery,conn))
                    {
                        cantidad = (int)comando.ExecuteScalar();//este me devuelve un soolo objeto, este trae un obj y quiero que me traiga un INT, POR ESO LO CASTEO

                    }
                    
                }
                return cantidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Pais GetPais(int id)//(*4)
        {
            throw new NotImplementedException();
        }

        public List<Pais> GetPaises()//luego de hacer la conexion voy hacer que me traiga la lista de paises 
        {
            List<Pais> lista=new List<Pais>();
            using (var _conn = new SqlConnection(cadenaDeConexion)) //aca creo realmente la conexion, despues de hacer esto le saque el "readonly" a IDbConnection (preguntar porque(*2)) //-->tengo la conexion
            { //lo que hace el using me permite una vez que uso la conexion automaticamente cierra la conexion y me libera los recurso //-->tengo el string del comando
                _conn.Open();//TENGO QUE ABRIR LA CONEXION
                var selectQuery = "SELECT * FROM Paises ORDER BY NombrePais"; //este SELECT es la sentencia de SQL que a mi me va a permitir traer todos los paises en orden//-->creo el comando
                using (var comando= new SqlCommand(selectQuery,_conn))//-->ahora tengo que ejecutar
                {
                    using (var reader=comando.ExecuteReader()) //me va a traer un conjunto de registros que yo tengo que leer
                    {//
                        while (reader.Read()) 
                        {
                            var pais = new Pais()//construyop mi pais
                            {
                                PaisId = reader.GetInt32(0),//leo la primer columna en sql
                                NombrePais = reader.GetString(1),//leo la segunda columna 
                                RowVersion = (byte[])reader[2] //leo la tercera aca casteo
                            };
                            lista.Add(pais);
                        }
                    }
                }
                return lista;
            }
        }
    }
}
