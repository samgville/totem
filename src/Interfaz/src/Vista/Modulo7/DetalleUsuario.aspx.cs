﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contratos.Modulo7;
using Presentadores.Modulo7;

namespace Vista.Modulo7
{
	public partial class DetalleUsuario : System.Web.UI.Page, IContratoDetalleUsuario
	{
		private PresentadorDetalleUsuario presentador;

		public DetalleUsuario()
		{
			this.presentador = new PresentadorDetalleUsuario(this);
		}
		
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Master.idModulo = "7";
			this.Master.presentador.CargarMenuLateral();
			presentador.DetalleDeUsuario();
		}

		public string Username
		{ set { this.username.InnerText = value; } }

		public string Nombre
		{ set { this.nombre.InnerText = value; } }

		public string Apellido
		{ set { this.apellido.InnerText = value; } }

		public string Rol
		{ set { this.rol.InnerText = value; } }

		public string Correo
		{ set { this.correo.InnerText = value; } }

		public string Cargo
		{ set { this.cargo.InnerText = value; } }

		public string MensajeAlerta
		{ set { this.alert.InnerText = value; } }

		public string TipoAlerta
		{ set { this.alert.Attributes.Add("class", value); } }
	}
}