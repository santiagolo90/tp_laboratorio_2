using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez.Santiago._2C_Libreria
{
    public class Harina : Producto
    {
        public enum ETipoHarina{CuatroCeros,Integral}

        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        #region Constructores

        static Harina()
        {
            Harina.DeConsumo = true;
        }

        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo)
            : base(codigoBarra, marca, precio)
        {
            this._tipo = tipo;
        }
        #endregion

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.60; }
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Marca: " + this._marca);
            sb.AppendLine("Codigo De Barra: " + this._codigoBarra);
            //sb.AppendLine("Precio: " + CalcularCostoDeProduccion);
            sb.AppendLine("Precio: " + this._precio);
            sb.AppendLine("Tipo: " + this._tipo);


            return sb.ToString();

        }

        public override string ToString()// sobrecarga de toString que llama al Mostrar Privado
        {
            return MostrarHarina();
        }
    }
}
