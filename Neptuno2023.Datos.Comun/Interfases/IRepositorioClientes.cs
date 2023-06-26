using Neptuno2023.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Comun.Interfases
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetClientes();
    }
}
