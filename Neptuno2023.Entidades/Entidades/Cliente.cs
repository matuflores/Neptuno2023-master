﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        public string CodPostal { get; set; }
        public string TelFijo { get; set; }
        public string TelMovil { get; set; }

        public byte[] RowVersion { get; set; }

        public Pais Pais { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
