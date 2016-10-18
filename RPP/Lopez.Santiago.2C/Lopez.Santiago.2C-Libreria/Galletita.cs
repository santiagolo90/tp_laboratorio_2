using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez.Santiago._2C_Libreria
{
    public class Galletita : Producto
    {

        protected float _peso;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return _precio * (float)0.33; }
        }

        #region Constructores

        static Galletita()
        {
            Galletita.DeConsumo = true;
        }

        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso)
            : base(codigoBarra, marca, precio)
        {
            this._peso = peso;
        }
        #endregion

        private string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Marca: " + g._marca);
            sb.AppendLine("Codigo De Barra: " + g._codigoBarra);
            //sb.AppendLine("Precio: " + g.CalcularCostoDeProduccion);
            sb.AppendLine("Precio: " + g._precio);
            sb.AppendLine("Peso: " + g._peso);


            return sb.ToString();

        }

        #region Sobrecargas
        public override string ToString() // sobrecarga de toString que llama al Mostrar Privado
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible";
        }
        #endregion
    }
}
