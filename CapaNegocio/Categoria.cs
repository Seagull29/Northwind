using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDato;

namespace CapaNegocio
{
    public class Categoria
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
        private string descripcion;
        private System.Byte [] foto;

        public Categoria(int id, string nombre, string desripcion, byte [] foto)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = desripcion;
            Foto = foto;
        }

        public Categoria(int id, string nombre, string desripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = desripcion;
        }

        public Categoria()
        {

        }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public Categoria(int id)
        {
            Id = id;
        }



        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public System.Byte [] Foto { get => foto; set => foto = value; }
        public bool Actualizar()
        {
            DataRow filas = datos.TraerDataRow("spActualizarCategories", id, nombre, descripcion, foto);
            byte codError = Convert.ToByte(filas["codError"]);
            mensaje = filas["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public bool Agregar()
        {
            DataRow filas = datos.TraerDataRow("uspAgregarCategories", nombre, descripcion, foto);
            byte codError = Convert.ToByte(filas["codError"]);
            mensaje = filas["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("uspBuscarCategories", texto, criterio);
        }

        public bool Eliminar()
        {
            DataRow filas = datos.TraerDataRow("uspEliminarCategories", id);
            byte codError = Convert.ToByte(filas["codError"]);
            mensaje = filas["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Listar()
        {
            return datos.TraerDataSet("uspListarCategories");
        }
    }
}
