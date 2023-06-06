using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Datos.Sql.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repositorioCiudades;
        //le pido al repositorio de paises que me de los nombre de los paises
        private readonly IRepositorioPaises _repositorioPaises;
        public ServiciosCiudades()
        {
            _repositorioCiudades=new RepositorioCiudades();
            _repositorioPaises = new RepositorioPaises();//esto lo hago para que envez de que me traiga solo el id  me traiga los nombres (*7d)
        }
        public void Borrar(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorioCiudades.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ciudad> GetCiudades()
        {
            try
            {
                //(*7d) cambio el retur no un var
                var lista= _repositorioCiudades.GetCiudades();
                foreach (var item in lista) //yo tengo a mi ciudad sin el pais necesito el pais
                {//yo tengo que pedirle el objeto pais al repositorio del pais
                    item.Pais = _repositorioPaises.GetPaisPorId(item.PaisId);//creo este metodo para poder traerme los paises de cada ciudad, lo creo aca y lo implemento en el repopaises 
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }
    }
}
