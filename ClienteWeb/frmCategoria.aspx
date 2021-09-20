<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCategoria.aspx.cs" Inherits="ClienteWeb.frmCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>CRUD de la tabla CATEGORIA</h1>
    <p>
        Id: <asp:TextBox runat="server" Id="txtId" />
    </p>
      <p>
        Nombre: <asp:TextBox runat="server" Id="txtNombre"/>
    </p>
    <p>
        Descripcion: <asp:TextBox runat="server" Id="txtDescripcion"/>
    </p>
      <p>
        Picture: 
          <asp:FileUpload runat="server" Id="fuImage"/>
          <asp:Button Text="Subir imagen" runat="server" ID="btnSubir" OnClick="btnSubir_Click"/>
    </p>
    <p>
        <asp:Image runat="server" ID="iFoto" />
    </p>
    <p>
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click"/>
        <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click" />
        <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click"/>
    </p>
    <p>
        Buscar: <asp:TextBox runat="server" Id="txtBuscar"/>
        <asp:DropDownList runat="server" ID="ddlCriterio">
            <asp:ListItem Text="Id" />
            <asp:ListItem Text="Nombre" />
            <asp:ListItem Text="Descripcion" />
        </asp:DropDownList>
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click"/>
    </p>
    <p>
        <asp:GridView runat="server" Id="gvCategoria"></asp:GridView>
    </p>

</asp:Content>
