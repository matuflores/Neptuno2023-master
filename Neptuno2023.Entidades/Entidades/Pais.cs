﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Entidades
{
    public class Pais:ICloneable//CON ESTO ME CREA UNA COPIA DEL PAIS
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; }
        public byte[] RowVersion { get; set; }//cuando pongo un atributo de clase "BYTE" tengo que ponerle siempre los []

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
