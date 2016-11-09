using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
   public sealed class Instructor : PersonaGimnasio
    {
       private Queue<Gimnasio.EClases> _clasesDelDia;
       static Random _random;

       #region Constructores
       public Instructor()//constructor con 0 parametros para serializar
       { }

       static Instructor()//static para iniciar random
       {
           _random = new Random();
       }
       public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
           : base(id, nombre, apellido, dni, nacionalidad)
       {
           this._clasesDelDia = new Queue<Gimnasio.EClases>();
           this._randomClases();//inicia el metodo random (tiene que ser de 0 a 4)
 
       }
       #endregion

       private void _randomClases()// random para las clases en clases del dia
       {
           this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
           this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
       }

       #region Sobrecargas
       protected override string ParticiparEnClase()//muestras las clases del dia 
       {

           StringBuilder sb = new StringBuilder();

           foreach (Gimnasio.EClases item in this._clasesDelDia)
           {
               sb.Append(item.ToString() + "\n");
           }

           return "CLASEs DEL DIA " +"\n"+ sb.ToString();

       }

       protected override string MostrarDatos()
       {
           return base.MostrarDatos() + ParticiparEnClase();
       }

       public override string ToString()//Sobrecarga ToString que muestra los datos protected
       {
           return MostrarDatos();
       }

       public static bool operator ==(Instructor i, Gimnasio.EClases clase)//si el elemento de la cola es igual a la clase = true
       {
           for (int j = 0; j < i._clasesDelDia.Count(); j++)
           {
               if (i._clasesDelDia.ElementAt(j) == clase)
                   return true;
           }
           return false;

       }

       public static bool operator !=(Instructor i, Gimnasio.EClases clase)
       { return !(i == clase); }
       #endregion
    }
}
