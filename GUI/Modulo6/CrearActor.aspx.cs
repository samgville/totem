﻿using System;

public partial class GUI_Modulo6_CrearActor : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";
        ((MasterPage)Page.Master).ShowDiv = true;
	}
}