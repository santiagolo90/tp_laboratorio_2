using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//para txt
using System.Xml;//para xml
using System.Xml.Serialization;//para xml

namespace Lopez.Santiago._2C_Libreria
{
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        private Estante()//constructor que inicializa la lista
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad):this()//contuctor que inicializa la capacidad y llama al constructor de Lista
        {
            this._capacidad = capacidad;
        }





        #region Sobrecargas
        public static bool operator ==(Estante e, Producto prod)//regresa True si el producto esta en la lista
        {
            bool rta = false;

            foreach (Producto item in e._productos)
            {
                if (item == prod)
                {
                    rta = true;
                    break;
                }
                rta = false;
            }
            return rta;
        }
        public static bool operator !=(Estante e, Producto prod)
        { return !(e == prod); }

        public static bool operator +(Estante e, Producto prod)//si el producto no esta en la lista y hay lugar, lo agrega
        {
            bool rta;
            //if (e._productos.Count == 0)
            //    e._productos.Add(prod);
            if (e._capacidad >= e._productos.Count && e != prod)
            {
                e._productos.Add(prod);
                rta = true;
            }
            else
                rta = false;

            return rta;
        }

        public static Estante operator -(Estante e, Producto prod)//recorre la lista de productos. Si encuentar uno igual, lo elimina
        {
            for (int i = 0; i < e._productos.Count; i++)
            {
                if (e._productos[i] == prod)
                {
                    e._productos.RemoveAt(i);
                    break;
                }

            }
            return e;

        }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)//recorre la lista eliminando los productos del EtipoProducto pasado por parametro
        {
            for (int i = 0; i < e._productos.Count; i++)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (e._productos[i] is Galletita)
                        {
                            e = e- e._productos[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (e._productos[i] is Gaseosa)
                        {
                            e =e- e._productos[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (e._productos[i] is Jugo)
                        {
                            e = e- e._productos[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Todos:
                        e._productos.Clear();
                        break;
                    //default:
                    //    break;
                }
                
            }
            //foreach (Producto item in e._productos)
            //{
            //    switch (tipo)
            //    {
            //        case ETipoProducto.Galletita:
            //            if (item is Galletita)
            //            {
            //                e -= item;
            //            }
            //            break;
            //        case ETipoProducto.Gaseosa:
            //            if (item is Gaseosa)
            //            {
            //                e -= item;
            //            }
            //            break;
            //        case ETipoProducto.Harina:
            //            if (item is Harina)
            //            {
            //                e -= item;
            //            }
            //            break;
            //        case ETipoProducto.Jugo:
            //            {
            //                e -= item;
            //            }
            //            break;
            //        case ETipoProducto.Todos:
            //            e._productos.Clear();
            //            break;
            //        default:
            //            break;

            //    }
            //}
            return e;
        }
        #endregion

        #region metodos

        public static string MostrarEstante(Estante e) // recorre el estante mostrado todo su contenido
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Capacidad: " + e._capacidad);

            foreach (Producto item in e._productos)
            {
                sb.AppendLine(item.ToString());//llama a la sobrecarga ToString de cada producto
            }

            return sb.ToString();
        }

        public float GetValorEstante(Producto.ETipoProducto tipo)//regresa el valor total(precio) , del tipo de producto pasado por parametro
        {
            float valor = 0;
            foreach (Producto item in _productos)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (item is Galletita)
                            //valor = valor + item.CalcularCostoDeProduccion;
                            valor = valor + item.Precio;
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (item is Gaseosa)
                            //valor = valor + item.CalcularCostoDeProduccion;
                            valor = valor + item.Precio;
                        break;
                    case Producto.ETipoProducto.Harina:
                        if (item is Harina)
                            //valor = valor + item.CalcularCostoDeProduccion;
                            valor = valor + item.Precio;
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (item is Jugo)
                            //valor = valor + item.CalcularCostoDeProduccion;
                            valor = valor + item.Precio;
                        break;
                    case Producto.ETipoProducto.Todos:
                        //valor = valor + item.CalcularCostoDeProduccion;
                        valor = valor + item.Precio;
                        break;

                }
    
            }
            return valor;
        }

        #endregion

        #region Propiedades
        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public float ValorEstanteTotal
        {

            get { return GetValorEstante(Producto.ETipoProducto.Todos); }
        }
        #endregion

        #region Extra
        public static bool GuardarEstante(Estante e)//intento archivo txt
        {
            bool aux = true;

            if (aux == true)
            {
                using (StreamWriter arch = new StreamWriter("D:\\MiEstante.txt", true)) //Guarda en la ubicacion D:
                //using (StreamWriter arch = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\MiEstante.txt", true)) //guarda en \bin\Debug
                //using (StreamWriter arch = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MiEstante.txt", true)) //Guarda en la carpeta que quiero
                {
                    //arch.WriteLine(e.ToString());MostrarEstante(Estante e)
                    arch.WriteLine(MostrarEstante(e));
                }
            }
            return aux;
        }

        public static bool Serializar(Estante e)//intento XML
        {
            bool aux = true;

                if (aux == true)
                {
                    //using (XmlTextWriter archivo = new XmlTextWriter(AppDomain.CurrentDomain.BaseDirectory + "\\MiEstanteXML.xml", System.Text.Encoding.UTF8))
                    // using (StreamReader arch = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MiEstanteXML.xml"))
                    //using (XmlTextWriter archivo = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MiEstanteXML.xml", System.Text.Encoding.UTF8))
                    using (XmlTextWriter arc = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MiEstanteXML.xml", System.Text.Encoding.UTF8))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(Estante));
                        serializador.Serialize(arc,e);
                    }
                }
            return aux;
        }
#endregion

    }
}
