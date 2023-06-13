using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno2023.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarComboPaises(ref ComboBox combo)//se lo paso por referencia no se lo paso por valor, no paso una copia sino que paso el objeto en si
        {//para que el combobox salga en orden por nombre se debe implementar desde el repositorio (select order by)
            IServiciosPaises serviciosPaises = new ServiciosPaises();
            var lista=serviciosPaises.GetPaises();
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "Seleccione Pais"
            };
            lista.Insert(0, defaultPais);
            combo.DataSource = lista;//fuente de datos
            combo.DisplayMember = "NombrePais";//mostrame de los datos que te paso los nombre de los paises
            combo.ValueMember = "PaisId";//cuando se seleciona un pais tomame el id
            combo.SelectedIndex = 0;//cuando te muestres situate en el primero(el primero va a ser "Selecione Pais")
        }
    }
}
