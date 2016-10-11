﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;//using

namespace Clase_12_Library
{
    public class Automovil : Vehiculo//Herencia de VeHiculo
    {
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas//public , set
        {
            get
            {
                return 4;
            }
            set { }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS :"+ this.CantidadRuedas);//agrego + y saco el {0} para usar Appendline
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();//Tostring
        }
    }
}
