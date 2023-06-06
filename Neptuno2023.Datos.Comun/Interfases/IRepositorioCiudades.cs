﻿using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Comun.Interfases
{
    public interface IRepositorioCiudades
    {
        List<Ciudad> GetCiudades();
        void Agregar(Ciudad ciudad);
        void Editar(Ciudad ciudad);
        int GetCantidad();
        bool Existe(Ciudad ciudad);
        void Borrar(int ciudadId);
    }
}