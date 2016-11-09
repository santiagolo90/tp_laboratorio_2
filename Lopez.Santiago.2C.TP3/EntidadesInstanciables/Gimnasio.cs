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

    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
       public enum EClases { CrossFit, Natacion, Pilates, Yoga }

       #region Atributos y contructor

       private List<Alumno> _alumnos;//pase a publico para que pueda serializar
       private List<Instructor> _instructores;//pase a publico para que pueda serializar
       private List<Jornada> _jornada;//pase a publico para que pueda serializar

       public List<Alumno> Alumnos
       { get { return this._alumnos; } }//Propiedades para poder serializar las listas privadas
       public List<Instructor> Instructores
       { get { return this._instructores; } }//Propiedades para poder serializar las listas privadas
       public List<Jornada> Jornada
       { get { return this._jornada; } }//Propiedades para poder serializar las listas privadas




       public Gimnasio()
       {
           this._alumnos = new List<Alumno>();
           this._instructores = new List<Instructor>();
           this._jornada = new List<Jornada>();
       }

       #endregion

       //Inderxador

       public Jornada this[int i]
       { get { return this._jornada[i]; } }

       //Inderxador

       #region SobreCarga =
       public static bool operator ==(Gimnasio g, Alumno a)
       {
           bool aux = false;
           foreach (Alumno item in g._alumnos)
           {
               if (item == a)//llama a sobrecarga == en personaGimnasio
               {
                   return aux = true;
                   //throw new AlumnoRepetidoException();
               }
           }
           return aux;
       }
       public static bool operator !=(Gimnasio g, Alumno a)
       { return !(g == a); }


       public static bool operator ==(Gimnasio g, Instructor i)
       {
           bool aux = false;
           foreach (Instructor item in g._instructores)
           {
               if (item == i)//llama a sobrecarga == en personaGimnasio
                   return aux = true;
               

           }
           return aux;

       }
       public static bool operator !=(Gimnasio g, Instructor i)
       { return !(g == i); }


       public static Instructor operator ==(Gimnasio g, EClases clase)
       {
           foreach (Instructor item in g._instructores)
           {
               if (item == clase)//Llama a sobrecarga Instructor-EClase(en instructor)
                   return item;
           }//Sino Excepción SinInstructorException

           throw new SinInstructorException();
       }

       public static Instructor operator !=(Gimnasio g, EClases clase)
       {
           foreach (Instructor item in g._instructores)
           {
               if (!(item == clase))
                   return item;
           }
           //throw new SinInstructorException();
           return null; //diponibles 

       }
       #endregion

       #region Sobrecarga +

       public static Gimnasio operator +(Gimnasio g, Alumno a)
       {
           if (g != a)
           {
               g._alumnos.Add(a);
               return g;
           }
           throw new AlumnoRepetidoException();

           //if (g._alumnos.Count == 0)
           //{
           //    g._alumnos.Add(a);
           //    return g;
           //}
           //else
           //    foreach (Alumno item in g._alumnos)
           //    {
           //        if (item == a)
           //        {
           //            throw new AlumnoRepetidoException();
                       
           //        }
           //    }
           //g._alumnos.Add(a);
           //return g;
  
       }

       public static Gimnasio operator +(Gimnasio g, Instructor i)
       {
           if (g != i)
               g._instructores.Add(i);
           return g;

           //if (g._instructores.Count == 0)
           //{
           //    g._instructores.Add(i);
           //    return g;
           //}
           //foreach (Instructor item in g._instructores)
           //{
           //    if (item != i)
           //        g._instructores.Add(i);
           //    return g;
           //}
           //return g; 
       }

       public static Gimnasio operator +(Gimnasio g, EClases clase)
       {
           //foreach (Instructor item in g._instructores)
           //{
           //    if ( item == clase)
           //        Jornada j = new Jornada(clase,item);
           //}

           Jornada j = new Jornada(clase, (g == clase));

           foreach (Alumno item in g._alumnos)
           {
               if (item == clase)
                   j = j + item;//sobrecargas jornada + alumno
                   
           }
           g._jornada.Add(j);//agrego la jornada
           return g;
        }

       #endregion

        #region XML

       public static bool Guardar(Gimnasio g)
       {
        Xml<Gimnasio>  MiXml = new  Xml<Gimnasio>();
        return MiXml.guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Gimnacio.xml", g);

       }

       public static Gimnasio Leer()
       {
           Gimnasio g;
           Xml<Gimnasio> MiXml = new Xml<Gimnasio>();
           MiXml.leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Gimnacio.xml", out g);
           return g;
       }



        #endregion

       #region mostrar

       private static string MostrarDatos(Gimnasio gim)
       {
           StringBuilder sb = new StringBuilder();
           foreach (Jornada item in gim._jornada)
           {
               sb.AppendLine(item.ToString());
           }

           return sb.ToString();
       }

       public override string ToString()
       {
           return MostrarDatos(this);
       }
       #endregion

    }
}
