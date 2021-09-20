using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace ClienteWeb
{
    public partial class frmRegion : System.Web.UI.Page
    {
        private static Region region = new Region();

        private void Listar()
        {
            gvRegion.DataSource = region.Listar().Tables[0];
            gvRegion.DataBind();
        }

        private void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar();
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text.Trim());
            string des = txtDescripcion.Text.Trim();
            region.Id = id;
            region.Description = des;
            // Llamamos a agregar, (bool) que devuelve un mensaje 
            if (region.Agregar())
            {
                
                Listar();
            } 
            // Mostrar el mensaje del procedimiento almacenado
            Response.Write("<script>alert('"+region.Mensaje+"');</script>");
            Limpiar();
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text.Trim());
            region.Id = id;
            if (region.Eliminar())
            {
                Listar();
            }
            Response.Write("<script>alert('" + region.Mensaje + "');</script>");
            Limpiar();

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text.Trim());
            string des = txtDescripcion.Text.Trim();
            region.Id = id;
            region.Description = des;
            // Llamamos a agregar, (bool) que devuelve un mensaje 
            if (region.Actualizar())
            {

                Listar();
            }
            // Mostrar el mensaje del procedimiento almacenado
            Response.Write("<script>alert('" + region.Mensaje + "');</script>");
            Limpiar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            string criterio = ddlCriterio.SelectedValue;
            gvRegion.DataSource = region.Buscar(texto, criterio).Tables[0];
            gvRegion.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            if (ddlCriterio.SelectedValue == "Descripcion")
            {
                Busqueda();
            }
        }

        private void Busqueda()
        {
            gvRegion.DataSource = region.Buscar(txtBuscar.Text.Trim(), "Descripcion").Tables[0];
            gvRegion.DataBind();
        }
    }
}