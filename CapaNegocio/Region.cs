using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Interface;
using CapaDato;

namespace CapaNegocio
{
    public class Region : IRegion
    {

        // Crear un objeto para utilizar la capa dato
        private Datos datos = new DatosSQL();

        // Declarar un atributo y propiedad para el mensaje del procedimiento almacenado
        private string mensaje;
        public string Mensaje
        {
            get => mensaje;
        }

        public int Id
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }
            

        public bool Actualizar()
        {
            // throw new NotImplementedException();
            DataRow fila = datos.TraerDataRow("spActualizarRegion", Id, Description);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar()
        {
            // throw new NotImplementedException();
            // Traer los datos de la consulta
            DataRow fila = datos.TraerDataRow("spAgregarRegion", Id, Description);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            Console.WriteLine("Mensaje:" + mensaje);
            if (codError == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public DataSet Buscar(string texto, string criterio)
        {
            // throw new NotImplementedException();
            return datos.TraerDataSet("spBuscarRegion", texto, criterio);
        }

        public bool Eliminar()
        {
            // throw new NotImplementedException();
            DataRow fila = datos.TraerDataRow("spEliminarRegion", Id);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet Listar()
        {
            // throw new NotImplementedException();
            return datos.TraerDataSet("spListarRegion");
        }
    }
}
