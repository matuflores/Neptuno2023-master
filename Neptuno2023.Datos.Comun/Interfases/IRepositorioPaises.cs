using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Comun.Interfases
{
    public interface IRepositorioPaises//siempre la interfaz va publica
    {
        List<Pais> GetPaises();
        Pais GetPais(int id);//NO RECUERDO PORQUE
        void Agregar(Pais pais);    
        //si el pais ya esta es un editar
        void Editar (Pais pais);
        int GetCantidad();
        bool Existe(Pais pais);
    }
}
