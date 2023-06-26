using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Dtos.Cliente
{
    public class ClienteListDto//como no forma parte del modelo de dominio, quiere decir esta entidad solo la voy a usar para mostrarla en un listado, mientras que la entidad Cliente es la que persisto
                               //objeto para transferir datos
    {//copio todo los datos de la entidad, solo dejo lo que voy a querer mostrar
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        //public string Direccion { get; set; }
        public string NombrePais { get; set; }
        //public Ciudad Ciudad { get; set; }
        public string NombreCiudad { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        //public string CodPostal { get; set; }
        //public string TelFijo { get; set; }
        //public string TelMovil { get; set; }

        //public Pais Pais { get; set; }
        //public Ciudad Ciudad { get; set; }
    }
}
