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
            try
            {
                _repositorioCiudades.Borrar(ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repositorioCiudades.Existe(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ciudad> Filtrar(Pais pais)
        {
            try
            {
                //esto me tiro error cuando quise filtrar porque filtro por pais y me traigo una lista de ciudades que no terngo el pais adentro
                //return _repositorioCiudades.Filtrar(pais);//hago siempre lo mismo, lo creo en el cs de form, creo el metodo en el servicio y del servicio lo implemento en el iservicio y ahora al repo
                var lista = _repositorioCiudades.Filtrar(pais);//cada repo es responsable de una tabla, por eso tengo que ir al repo de pais para que me lo cargue en ciudades
                foreach (var item in lista) //TODO EL FOREACH ESTA EXPLICADO ABAJO EN EL METODDO GETCIUDADES
                {
                    item.Pais = _repositorioPaises.GetPaisPorId(item.PaisId);
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
            try
            {
                if (ciudad.CiudadId==0)
                {
                    _repositorioCiudades.Agregar(ciudad);
                }
                else
                {
                    _repositorioCiudades.Editar(ciudad);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
