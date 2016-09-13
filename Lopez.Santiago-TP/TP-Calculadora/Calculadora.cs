using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calculadora
{
    class Calculadora
    {
        public Calculadora()
        { }
        //1234

        /// <summary>
        /// Metodo con un switch que realiza las operaciones de la calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double result=0;
            switch (validarOperador(operador))
            {
                case "+":
                    {       
                        result = numero1.getNumero() + numero2.getNumero();
                        return result;
                        break;
                    }
                case "-":
                    {
                        result = numero1.getNumero() - numero2.getNumero();
                        return result;
                        break;
                    }
                case "*":
                    {
                        result = numero1.getNumero() * numero2.getNumero();
                        return result;
                        break;
                    }
                case "/":
                    {
                        if (numero2.getNumero() == 0)
                            result = 0;
                        else
                            result = numero1.getNumero() / numero2.getNumero();

                        return result;
                        break;
                    }
            }
            return result;
        }

        /// <summary>
        /// metodo que pone los valores en 0
        /// </summary>
        /// <returns></returns>
        public string Limpiar()
        {
            return "0";

        }

        /// <summary>
        /// Validacion de Operador
        /// Si es distinto a "+,-,*,/" retorna un "+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {

            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador;
            //switch (operador)
            //{
            //    case "+":
            //        {
            //            operador ="+";
            //            return operador;
            //            break;
            //        }
            //    case "-":
            //        {
            //            operador ="-";
            //            return operador;
            //            break;
            //        }
            //    case "*":
            //        {
            //            operador ="*";
            //            return operador;
            //            break;
            //        }
            //    case "/":
            //        {
            //            operador ="/";
            //            return operador;
            //            break;
            //        }
            //    default:
            //            {
            //                operador="+";
            //                return operador;
            //                break;
            //            }
            //}

            

        }

    }
}
