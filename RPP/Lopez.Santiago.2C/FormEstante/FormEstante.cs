using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lopez.Santiago._2C_Libreria;
using TestEstante;

namespace FormEstante
{
    static class FormEstante
    {
        public static int OrdenarProductos(Producto proUno, Producto proDos)//compara 2 string para ordenar por el metodo Sort
        {
            return String.Compare(proUno.Marca.ToString(), proUno.Marca.ToString());
        }
    }
}
