using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;//using


namespace Clase_12_Library
{
    public class Camion : Vehiculo//Herencia de VeHiculo
    {
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color) 
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas//public , set y override
        {
            get
            {
                return 8;
            }
            set { }
        }

        public override sealed string Mostrar() //publico
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS :" + this.CantidadRuedas);//agrego + y saco el {0} para usar Appendline
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();//ToString
        }
    }
}
