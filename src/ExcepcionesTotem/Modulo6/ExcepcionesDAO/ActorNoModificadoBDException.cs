﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class ActorNoModificadoBDException : DAOException
    {
       public ActorNoModificadoBDException()
            : base()
        { }

        public ActorNoModificadoBDException(string message)
            : base(message)
        {
        }

        public ActorNoModificadoBDException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ActorNoModificadoBDException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
