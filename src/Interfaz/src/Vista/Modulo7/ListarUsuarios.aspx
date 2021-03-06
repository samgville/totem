﻿<%@ Page Title="" Language="C#"  MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="Vista.Modulo7.ListarUsuarios" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Usuarios del sistema
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

        <div id="alert" runat="server">
        </div>
    <form id="lista_form" class="form-horizontal" action="#" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
    <div class="table-responsive">
		<table id="table_users" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>Usuario</th>
					<th>Nombre</th>
					<th>Apellido</th>
					<th>Cargo</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody id="tablebody" runat="server">
          
            </tbody>
		</table>
     <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
     <ContentTemplate>
        <div id="modal_delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title" >Eliminaci&oacute;n de Usuario</h4>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
                <p>Seguro que desea eliminar el usuario:</p>
                <p runat="server" id="user_name"></p>
            </div>
          </div>
        </div>
        <div class="modal-footer">
         <button id="eliminar" runat="server" class="btn btn-primary" type="submit" data-dismiss="modal" onserverclick="evento_eliminar">Eliminar</button>
          <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>         
        </div>
      </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
  </div><!-- /.modal -->
     </ContentTemplate>
    </asp:UpdatePanel>
	</div>
</form>
</asp:Content>
