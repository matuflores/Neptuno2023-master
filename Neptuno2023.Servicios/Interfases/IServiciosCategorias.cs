using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosCategorias
    {
        List<Categoria> GetCategorias();
        void Guardar(Categoria categoria);//para que no me salga erro lo tengo que implementar en "servicioscategoria"
    }
}
