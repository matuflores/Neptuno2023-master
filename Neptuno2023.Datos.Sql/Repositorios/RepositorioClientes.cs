using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Entidades.Dtos.Cliente;
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
    public class RepositorioClientes : IRepositorioClientes
    {
        public string cadenaDeConexion;

        public RepositorioClientes()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public List<ClienteListDto> GetClientes()
        {
           
                List<ClienteListDto> lista = new List<ClienteListDto>();
                using (var _conn = new SqlConnection(cadenaDeConexion))
                {
                    _conn.Open();
                    string selectQuery = @"SELECT ClienteId, NombreCliente, PaisId, CiudadId 
                                     FROM Clientes
                                     ORDER BY NombreCliente";
                    using (var comando = new SqlCommand(selectQuery, _conn))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var clienteDto = ConstruirClienteDto(reader);
                                lista.Add(clienteDto);
                            }
                        }
                    }
                }
                return lista;
            
        }

        private ClienteListDto ConstruirClienteDto(SqlDataReader reader)
        {
            return new ClienteListDto()//esto lo uso en otro lugares por lo que puedo hacer un metodo para reutilizar
            {
                ClienteId = reader.GetInt32(0),//leo la primer columna en sql
                NombreCliente = reader.GetString(1),//leo la segunda columna 
                PaisId = reader.GetInt32(2),
                CiudadId = reader.GetInt32(3)
            };
        }
    }
}
