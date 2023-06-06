using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Entidades
{
    public class Ciudad:ICloneable
    {
        public int CiudadId { get; set; }
        public int PaisId { get; set; }
        public string NombreCiudad { get; set; }
        public byte[] RowVersion { get; set; }

        public Pais Pais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
