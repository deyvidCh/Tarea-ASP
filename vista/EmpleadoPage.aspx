<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="EmpleadoPage.aspx.cs" Inherits="vista.EmpleadoPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .custom-gridview {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

    .custom-gridview th, .custom-gridview td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: left;
    }

    .custom-gridview th {
        background-color: #f2f2f2;
        font-weight: bold;
    }

    .custom-gridview tr:hover {
        background-color: #f5f5f5;
    }

.btn {
    margin: 5px;
}

.label-text {
    font-weight: bold;
    margin-top: 10px;
    display: block;
}

.form-control {
    width: 100%;
    padding: 8px;
    margin-top: 5px;
    margin-bottom: 10px;
    box-sizing: border-box;
}
    </style>
    <h1>Formulario Empleados</h1>
    <asp:Label ID="lbl_codigo" runat="server" CssClass="label-text" Text="Codigo"></asp:Label>
    <asp:TextBox ID="txt_codigo" runat="server" CssClass="form-control" placeholder="E001"></asp:TextBox>
    
    <asp:Label ID="lbl_nombres" runat="server" CssClass="label-text" Text="Nombres"></asp:Label>
    <asp:TextBox ID="txt_nombres" runat="server" CssClass="form-control" placeholder="Nombre 1 Nombre 2"></asp:TextBox>
    
    <asp:Label ID="lbl_apellidos" runat="server" CssClass="label-text" Text="Apellidos"></asp:Label>
    <asp:TextBox ID="txt_apellidos" runat="server" CssClass="form-control" placeholder="Apellido 1 Apellido 2"></asp:TextBox>
    
    <asp:Label ID="lbl_direccion" runat="server" CssClass="label-text" Text="Direccion"></asp:Label>
    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" placeholder="Zona 2 Villa Nueva"></asp:TextBox>
    
    <asp:Label ID="lbl_telefono" runat="server" CssClass="label-text" Text="Telefono"></asp:Label>
    <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control" TextMode="Number" placeholder="51645972"></asp:TextBox>
    
    <asp:Label ID="lbl_fn" runat="server" CssClass="label-text" Text="Fecha Nacimiento"></asp:Label>
    <asp:TextBox ID="txt_fn" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    
    <asp:Label ID="lbl_sangre" runat="server" CssClass="label-text" Text="Puesto"></asp:Label>
    <asp:DropDownList ID="drop_puesto" runat="server" CssClass="form-control"></asp:DropDownList>
    
    <p></p>
    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btn_agregar_Click" />
    <asp:Button ID="btn_modificar" runat="server" OnClick="btn_modificar_Click" Text="Modificar" CssClass="btn btn-success" Visible="False" />
    <asp:Label ID="lbl_mensaje" runat="server" CssClass="alert-info"></asp:Label>
    <p></p>
    
    <asp:GridView ID="grid_empleados" runat="server" AutoGenerateColumns="False" CssClass="custom-gridview" DataKeyNames="id,id_puesto" OnRowDeleting="grid_empleados_RowDeleting" OnSelectedIndexChanged="grid_empleados_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Select" Text="Ver" CssClass="btn btn-warning" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" CssClass="btn btn-danger" OnClientClick="javascript:if(!confirm('¿Desea Eliminar?'))return false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="fecha_nacimiento" DataFormatString="{0:d}" HeaderText="Nacimiento" />
            <asp:BoundField DataField="puesto" HeaderText="Puesto" />
        </Columns>
    </asp:GridView>
</asp:Content>
