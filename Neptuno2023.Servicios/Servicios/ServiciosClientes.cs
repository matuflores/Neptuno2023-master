using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Datos.Sql.Repositorios;
using Neptuno2023.Entidades.Dtos.Cliente;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorioClientes;
        private readonly IRepositorioPaises _repositorioPaises;
        private readonly IRepositorioCiudades _repositorioCiudades;
        public ServiciosClientes()
        {
            _repositorioClientes = new RepositorioClientes();     
            _repositorioPaises= new RepositorioPaises();
            _repositorioCiudades = new RepositorioCiudades();
        }
        public List<ClienteListDto> GetClientes()
        {
            try
            {
                var listaClientes = _repositorioClientes.GetClientes();
                foreach (var item in listaClientes)
                {
                    var pais = _repositorioPaises.GetPaisPorId(item.PaisId);
                    var ciudad = _repositorioCiudades.GetCiudadPorId(item.CiudadId);
                    item.NombrePais = pais.NombrePais;
                    item.NombreCiudad = ciudad.NombreCiudad;
                }
                return listaClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
