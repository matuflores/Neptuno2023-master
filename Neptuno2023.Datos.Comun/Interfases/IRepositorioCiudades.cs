using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Comun.Interfases
{
    public interface IRepositorioCiudades
    {
        List<Ciudad> GetCiudades();
        void Agregar(Ciudad ciudad);
        void Editar(Ciudad ciudad);
        int GetCantidad();
        bool Existe(Ciudad ciudad);
        void Borrar(int ciudadId);
        List<Ciudad> Filtrar(Pais pais);
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);// esto se crear como un OBJECT por eso hay que cambiarlo a una list
        Ciudad GetCiudadPorId(int ciudadId);
    }
}
