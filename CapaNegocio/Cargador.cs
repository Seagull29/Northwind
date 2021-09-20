using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using System.Data;

namespace CapaNegocio
{
    public class Cargador
    {
        private Datos datos = new DatosSQL();
        //Declarar un atributo y propiedad para el mensaje del PA
        string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
        }

        //Atributos de la clase
        private int id;
        private string nombre;
        private string telefono;

        public Cargador(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool Actualizar()
        {
            DataRow filas = datos.TraerDataRow("spActualizarCargador", id, nombre, telefono);
            byte codError = Convert.ToByte(filas["codError"]);
            mensaje = filas["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public bool Agregar()
        {
            DataRow filas = datos.TraerDataRow("spAgregarCargador", id, nombre, telefono);
            byte codError = Convert.ToByte(filas["codError"]);
            mensaje = filas["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarCargador", texto, criterio);
        }

        public bool Eliminar()
        {
            DataRow filas = datos.TraerDataRow("spEliminarCargador", id);
            byte codError = Convert.ToByte(filas["codError"]);
            mensaje = filas["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Listar()
        {
            return datos.TraerDataSet("spListarCargador");
        }
    }
}
