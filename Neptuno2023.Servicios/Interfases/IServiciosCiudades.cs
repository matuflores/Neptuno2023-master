using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosCiudades
    {
        List<Ciudad> GetCiudades();//
        void Guardar(Ciudad ciudad);//
        int GetCantidad();//
        bool Existe(Ciudad ciudad);//
        void Borrar(int ciudadId);//
        List<Ciudad> Filtrar(Pais pais);
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);
    }
}
