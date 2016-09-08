using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Calculadora
{
    class Numero
    {
        private double _numero;

        #region Constructores

        public Numero()
        {
            this._numero = 0;
        }

        public Numero(string numero)
        {
            //this._numero = double.Parse(numero);
            setNumero(numero);
        }

       public Numero(double numero)
        {
            this._numero = numero;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// propiedad de solo escritura
        /// escribe en el atributo privado el valor
        /// que devuelve el tryParse entre string y double
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        { this._numero = validarNumero(numero); }

        /// <summary>
        /// propiedad de solo lectura publica
        /// que retorna el valor privado ya validado
        /// por el tryParse entre string y double
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        { return this._numero; }

        #endregion

        #region Metodos

        /// <summary>
        ///  Valida si el string ingresado se puede
        ///  Pasar a double
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static double validarNumero(string n)
        {
            double temp = 0;
            double.TryParse(n, out temp);
            return temp;
        }

        #endregion

    }
}
