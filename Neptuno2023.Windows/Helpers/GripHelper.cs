using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno2023.Windows.Helpers
{
    public static class GripHelper//la clase static no hace falta instanciarla para usar sus metodos
    {
        
        public static void LimpiarGrilla(DataGridView dgv)//Este metodo lo uso para no tener que reescribir codigo cada vez que vaya a usarlo. Lo utilizo
        {
            dgv.Rows.Clear();
        }

        
        public static DataGridViewRow ConstruirFila(DataGridView dgv)//Este metodo me va devolver un objeto de tipo datagridview por eso no va VOID
        {
            DataGridViewRow r = new DataGridViewRow();//creo una nueva fila
            r.CreateCells(dgv);//aca el parametro siempre corroborar que tenga el mismo nombre que arriba!
            return r;
        }

        public static void SetearFila(DataGridViewRow r, object obj)//como este metodo va a recibir objetos de tipo "Pais", de "Ciudades" etc, no se puede especifica un unico, por eso se pone el tipo "OBJECT"
        {
            switch (obj)//segun el objeto que pasen voy a implementar tal tipo
            {
                case Pais pais:
                    //r.Cells[colPais.Index].Value = pais.NombrePais;//para no tener problemas con los nombres le pongo el subindice
                    r.Cells[0].Value = pais.NombrePais;
                    break;
                case Ciudad ciudad:
                    r.Cells[0].Value = ciudad.Pais.NombrePais;
                    r.Cells[1].Value = ciudad.NombreCiudad;
                    break;
                case Categoria categoria:
                    r.Cells[0].Value = categoria.NombreCategoria;//a la fila le digo que voy a seleccionar la celda/columna que le indico y uso el index para la posicion, uso el value para decirle que va a tomar el valor que le paso. del objeto categoria le voy asignar el valor del atributo que le indicop
                    r.Cells[1].Value = categoria.Descripcion;
                    break;

            }
            r.Tag = obj;
        }

        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }
    }
}
