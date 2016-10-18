using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez.Santiago._2C_Libreria
{
    public class Gaseosa : Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.42; }
        }

        #region Constructores

        static Gaseosa()
        {
            Gaseosa.DeConsumo = true;
        }

        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros)
            : base(codigoBarra, marca, precio)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto p, float litros)
            : this((int)p, p.Precio, p.Marca, litros)
        {

        }
        #endregion

        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Marca: " + this._marca);
            sb.AppendLine("Codigo De Barra: " + this._codigoBarra);
            //sb.AppendLine("Precio: " + CalcularCostoDeProduccion);
            sb.AppendLine("Precio: " + this._precio);
            sb.AppendLine("Litros: " + this._litros);


            return sb.ToString();

        }
        #region Sobrecargas
        public override string ToString()// sobrecarga de toString que llama al Mostrar Privado
        {
            return MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }
        #endregion
    }
}
