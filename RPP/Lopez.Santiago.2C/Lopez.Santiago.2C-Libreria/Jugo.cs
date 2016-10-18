using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez.Santiago._2C_Libreria
{
    public class Jugo : Producto
    {
        public enum ESaborJugo{Pasable,Asqueroso,Rico}

        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.40; }
        }

        #region Constructores
        static Jugo()
        {
            Jugo.DeConsumo = true;
        }

        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor):base(codigoBarra, marca, precio)
        {
            this._sabor = sabor;
        }
        #endregion

        private string MostrarJugo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Marca: " + this._marca);
            sb.AppendLine("Codigo De Barra: " + this._codigoBarra);
            //sb.AppendLine("Precio: " + CalcularCostoDeProduccion);
            sb.AppendLine("Precio: " + this._precio);
            sb.AppendLine("Sabor: " + this._sabor);


            return sb.ToString();
        }

        #region Sobrecargas
        public override string ToString()// sobrecarga de toString que llama al Mostrar Privado
        {
            return MostrarJugo();
        }

        public override string Consumir()
        {
            return " Bebible";
        }
        #endregion

    }
}
