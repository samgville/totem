﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ConsultarTodosActoresDAOException : ExcepcionesTotem.ExceptionTotem
    {
        public ConsultarTodosActoresDAOException()
            : base()
        { }

        public ConsultarTodosActoresDAOException(string message)
            : base(message)
        {
        }

        public ConsultarTodosActoresDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarTodosActoresDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
