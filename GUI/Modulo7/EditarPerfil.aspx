﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="EditarPerfil.aspx.cs" Inherits="GUI_Modulo7_EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Editar Perfil
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
            <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
                <div id="alertlocal" >
                </div>
            <form id="detalle-form" class="form-horizontal" action="#">
            <div class="form-group">
		        <div  class="col-sm-10 col-md-10 col-lg-10">
                    <label>Nombre de Usuario: </label>
                    <input type="text" value="jaklupo" class="form-control" name="usuario" />
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-5 col-md-5 col-lg-10">
				    <label>Nombre:</label>
                    <input type="text" value="Javier" class="form-control" name="nombre"/>
			    </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Apellido: </label>
                    <input type="text" value="Hernandez" class="form-control" name="apellido"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Correo: </label>
                    <input type="text" value="jaklupo@totem.com" class="form-control" name="correo"/>
		        </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-5 col-lg-5">
				    <label>Cargo:</label>
                    <input type="text" value="Lider de Proyecto" class="form-control" name="cargo" />
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-10 col-lg-10">
				    <label>Pregunta de Seguridad:</label>
                    <input type="text" value="Como se llama tu primera casa?" class="form-control" name="pregunta"/>
			    </div>
            </div>
            <div class="form-group">
			    <div class="col-sm-10 col-md-10 col-lg-10">
				    <label>Respuesta: </label>
                    <input type="text" value="Cantares" class="form-control" name="respuesta" />
			    </div>
            </div>
            <div class="form-group">
                &nbsp; &nbsp;
                <button class="btn btn-info" data-toggle="modal" data-target="#modal-change-pswd">Cambiar Contrase&ntilde;a</button>
            </div>
                <div class="form-group">
                         &nbsp; &nbsp;
				            <button class="btn btn-primary">Editar</button>
                        &nbsp;
				            <button class="btn btn-default">Cancelar</button>
		        </div>
            </form>
        </div>
            <div id="modal-change-pswd" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title" >Cambiar Contrase&ntilde;a</h4>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
                <form id ="pswd-form">
              <div class="form-group">
                <label for="pswd-viejo" class="control-label">Contrase&ntilde;a Vieja:</label>
                <input type="password" class="form-control" id="pswd-viejo"  name="pswdviejo"/>
              </div>
              <div class="form-group">
                <label for="pswd-nuevo" class="control-label">Contrase&ntilde;a Nueva:</label>
                <input class="form-control" type="password" id="pswd-nuevo" name="pswdnuevo"/>
              </div>
              <div class="form-group">
                <label for="pswd-nuevo-conf" class="control-label">Confirmar Contrase&ntilde;a Nueva:</label>
                <input class="form-control" type="password" id="pswd-nuevo-conf" name="pswdnuevoconf"/>
              </div>
        </form>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
          <a id="btn-confirm" href="#" class="btn btn-primary" >Confirmar</a>
        </div>
      </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
  </div><!-- /.modal -->
    <script src="js/Validacion.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#modal-change-pswd').on('shown.bs.modal', function () {
                $('#pswd-form').formValidation('resetForm', true);
            });
            $('#btn-confirm').on('click', function () {
                $('#modal-change-pswd').modal('hide');//se esconde el modal
                $('#alertlocal').addClass("alert alert-success alert-dismissible");
                $('#alertlocal').text("Se ha cambiado la contraseña con éxito");
            });
        });
    </script>
</asp:Content>

