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
    public class ServiciosPaises : IServiciosPaises
    {
        private readonly IRepositorioPaises _repositorioPaises;//se entiendde con la capa de datos, por eso usa el repositorio de la capa Datos.Comun
        public ServiciosPaises()
        {
            _repositorioPaises=new RepositorioPaises();//el _reposi... es de tipo de una interfaz y la apunto al repositorio dde Sql **aca lo que hago es conectarme a SQL para pedirle los datos que necesito** 
        }

        public void Guardar(Pais pais)
        {
            try
            {
                //paso(Editar Pais) el metodo sabe si tiene que guardar o actualizar dependiendo si el objeto tiene ID, si el objeto ya tiene un ID es porque va a edditar, si no tiene ID es porque es un pais nuevo y va a guardarlo
                if (pais.PaisId==0)
                {
                    _repositorioPaises.Agregar(pais);
                }
                else
                {
                    _repositorioPaises.Editar(pais);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public List<Pais> GetPaises()
        {//me tengo que llevar la lista de paises
            try//un bloque try se usa para separar el código que podría verse afectado por una excepción
            {
                return _repositorioPaises.GetPaises(); //el repositorio le pasa al servicio los datos
            }
            catch (Exception ex)
            {
                //si pongo cw tengo que poner si o si throw para devolver
                Console.WriteLine(ex);
                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorioPaises.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(int paisId)
        {
            try
            {
                _repositorioPaises.Borrar(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Existe(Pais pais)
        {
            try
            {//como servicios solo es un pasa mano se lo piedo al repositorio el metodo, asique lo genero
                return _repositorioPaises.Existe(pais);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Pais GetPaisPorId(int paisId)
        {
            try
            {
                return _repositorioPaises.GetPaisPorId(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
