﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo3
{

    /// <summary>
    /// Contrato asociado a la vista listar involucrado
    /// </summary>
    public interface IContratoListarInvolucrado
    {
        string laTabla { get; set; }
        String alertRol { set; }
        String alertClase { set; }
        String alert { set; }
    }
}
