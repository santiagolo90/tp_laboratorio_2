﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private static string mensajeBase;

        public DniInvalidoException():base()
        {
            DniInvalidoException.mensajeBase = "DNI invalido";
        }

        public DniInvalidoException(Exception e)
            : base(DniInvalidoException.mensajeBase, e)
        {}

        public DniInvalidoException(string message):base(message)
        { }

        public DniInvalidoException(string message, Exception e):base(message,e)
        { }

    }
}
