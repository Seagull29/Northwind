<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegion.aspx.cs" Inherits="ClienteWeb.frmRegion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>CRUD Region</h1>
    <p>
        ID: <asp:TextBox runat="server" Id="txtId"/> 
    </p>
    <p>
        Descripcion <asp:TextBox runat="server" Id="txtDescripcion"/>
    </p>
    <p>
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click"/>
        <asp:Button Text="Eliminar" runat="server"  ID="btnEliminar" OnClick="btnEliminar_Click"/>
        <asp:Button Text="Actualizar" runat="server"  ID="btnActualizar" OnClick="btnActualizar_Click"/>
    </p>
    <p>
        Buscar: <asp:TextBox runat="server"  ID="txtBuscar" OnTextChanged="txtBuscar_TextChanged"/>
        <asp:DropDownList runat="server" ID="ddlCriterio">
            <asp:ListItem Text="Id" />
            <asp:ListItem Text="Descripcion" />
        </asp:DropDownList>
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click"/>
    </p>
    <p>
        <asp:GridView runat="server"  ID="gvRegion"/>
    </p>
    

</asp:Content>
