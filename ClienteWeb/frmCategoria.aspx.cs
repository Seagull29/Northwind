using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CapaNegocio;

namespace ClienteWeb
{
    public partial class frmCategoria : System.Web.UI.Page
    {

        private string imagePath = "";
        private Categoria categoria = new Categoria();
        
        private void Listar()
        {
            gvCategoria.DataSource = new Categoria().Listar();
            gvCategoria.DataBind();
        } 

        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            iFoto.ImageUrl = null;
            imagePath = null;
        }

        private byte[] StrToByteArray(string value)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar();
            }
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Images/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            fuImage.SaveAs(folderPath + Path.GetFileName(fuImage.FileName));

            string path = "~/Images/" + Path.GetFileName(fuImage.FileName);
            string path1 = Path.GetFullPath(fuImage.FileName);
            iFoto.ImageUrl = path;
            imagePath = HttpContext.Current.Server.MapPath(path1);
            categoria.Foto = StrToByteArray(imagePath);
            byte[] bytes = File.ReadAllBytes(imagePath);
            Response.Write("<script>alert('" + bytes.ToString() + "');</script>");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            categoria.Nombre = txtNombre.Text.Trim();
            categoria.Descripcion = txtDescripcion.Text.Trim();
     
           /* if (imagePath != "")
            {
                categoria.Foto = StrToByteArray( imagePath);
            }*/

            if (categoria.Agregar())
            {

                Listar();
            }
            // Mostrar el mensaje del procedimiento almacenado
            Response.Write("<script>alert('" + categoria.Mensaje + "');</script>");
            Limpiar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria(int.Parse(txtId.Text.Trim()));
            if (categoria.Eliminar())
            {

                Listar();
            }
            // Mostrar el mensaje del procedimiento almacenado
            Response.Write("<script>alert('" + categoria.Mensaje + "');</script>");
            Limpiar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            categoria.Id = int.Parse(txtId.Text.Trim());
            categoria.Nombre = txtNombre.Text.Trim();
            categoria.Descripcion = txtDescripcion.Text.Trim();

            /*if (imagePath != "")
            {
                categoria.Foto = StrToByteArray(imagePath);
            }*/

            if (categoria.Actualizar())
            {

                Listar();
            }
            // Mostrar el mensaje del procedimiento almacenado
            Response.Write("<script>alert('" + categoria.Mensaje + "');</script>");
            Limpiar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            string criterio = ddlCriterio.SelectedValue;
            gvCategoria.DataSource = new Categoria().Buscar(texto, criterio).Tables[0];
            gvCategoria.DataBind();
        }
    }
}