using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IConsultas
    {
        DataSet Listar();
        bool Agregar();
        bool Eliminar();
        bool Actualizar();
        DataSet Buscar(string texto, string criterio);
    }
}
