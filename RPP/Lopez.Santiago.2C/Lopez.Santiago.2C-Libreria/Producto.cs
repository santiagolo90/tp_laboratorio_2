using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez.Santiago._2C_Libreria
{
    public abstract class Producto
    {
        public enum ETipoProducto{Galletita,Jugo,Harina,Gaseosa,Todos}//enumero EtipoProducto

        public enum EMarcaProducto{Favorita,Pitusas,Diversión,Naranjú,Swift}//Enumerado EMarcaProducto

        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public Producto(int codigoBarra, EMarcaProducto marca, float precio) //constructor de 3 elemenos
        {
            this._codigoBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;
        }
        #region Propiedades

        public EMarcaProducto Marca//Propiedad de Solo lectura que obtiene La marca
        {
            get { return this._marca; }
        }

        public float Precio//Propiedad de Solo lectura que obtiene el Precio
        {
            get { return this._precio; }
        }

        public abstract float CalcularCostoDeProduccion //propiedad Abastracta para calcular los costos
        {
            get;
        }
        #endregion

        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Marca: " + p._marca);
            sb.AppendLine("Codigo de barra: " + p._codigoBarra);
            sb.AppendLine("Precio: " + p._precio);

            return sb.ToString();
        }

        #region Sobrecargas

        public static bool operator ==(Producto prodUno, Producto prodDos) //Compara que 2 productos sean del mismo tipo, codigo de barra y marca
        {
            if (Equals(prodUno, prodDos) == true && prodUno._codigoBarra == prodDos._codigoBarra && prodUno._marca == prodDos._marca)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }

        public static bool operator ==(Producto prodUno, EMarcaProducto marca)// compara que el producto tenga la misma marca del parametro
        {
            if (prodUno._marca == marca)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }

        public static explicit operator int(Producto p)// sobrecarga para llamar en constructor de gaseosa y en sort
        {
            return p._codigoBarra;
        }

        public static implicit operator string(Producto p) //sobrecarga que llama al metodo privado MostrarProducto
        {
            return MostrarProducto(p);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(obj, (Producto)obj) == true;
        }

        #endregion

        public virtual string Consumir()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Parte de una mezcla");

            return sb.ToString();
        }
    }
}
