using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IRegion
    {

        // Declarar los metodos de la interface que permita implementar el CRUD Region
        DataSet Listar();
        bool Agregar();
        bool Actualizar();
        bool Eliminar();
        DataSet Buscar(string texto, string criterio);

    }
}
