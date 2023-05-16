using Neptuno2023.Datos.Comun.Interfases;
using Neptuno2023.Datos.Sql.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosCategorias : IServiciosCategorias
    {//el servicio se entiende con el repositorio por lo tanto va a tener una manera de leerlo: paso 8(*2)
        private readonly IRepositorioCategorias _repositorioCategorias;
        public ServiciosCategorias()
        {
            _repositorioCategorias=new RepositorioCategorias();//el repo es el encargado de cuando el servicio le pida las categorias(metodo de GetCategorias) pueda pasarselas
        }

        public List<Categoria> GetCategorias()
        {
            try
            {
                return _repositorioCategorias.GetCategorias();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId==0)
                {
                    _repositorioCategorias.Agregar(categoria);
                }
                else
                {
                    _repositorioCategorias.Editar(categoria);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
