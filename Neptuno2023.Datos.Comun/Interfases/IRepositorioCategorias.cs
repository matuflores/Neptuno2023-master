using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Comun.Interfases
{
    public interface IRepositorioCategorias
    {
        List<Categoria> GetCategorias();

        Categoria GetCategoria(int id);
        void Agregar (Categoria categoria);
        void Editar(Categoria categoria);
    }
}
