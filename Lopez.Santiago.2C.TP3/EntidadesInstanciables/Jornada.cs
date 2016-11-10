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

    public class Jornada
    {
        #region Atributos y constructores
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        public List<Alumno> Alumnos
        { get { return this._alumnos; } }//Propiedades para poder serializar las listas privadas
        public Gimnasio.EClases Clase
        { get { return this._clase; } }//Propiedades para poder serializar las listas privadas
        public Instructor Instructor
        { get { return this._instructor; } }//Propiedades para poder serializar las listas privadas



        private Jornada()//inicializa la lista de alumnos
        { _alumnos = new List<Alumno>(); }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        

        #region Sobrecargas
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool aux = false;
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)//LLama a la sobrecarga == de alumno y Clase (en Alumno)
                    return aux = true;
            }
            return aux;
            //return (a == j._clase);
        }
        public static bool operator !=(Jornada j, Alumno a)
        { return !(j == a); }


        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)//Sobrecarga == en PersonaGimnasio
                    throw new AlumnoRepetidoException();

            }
            j._alumnos.Add(a);
            return j;
 
        }

        public override string ToString()//Sobrecarga ToString que muestra la jornada con su instructor y sus alumnos
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.Append("CLASE DE " + this._clase.ToString() +" " );
            sb.AppendLine("POR: " + this._instructor.ToString() );
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("----------------");
            return sb.ToString();
        }

        #endregion

        #region TXT
        public static bool Guardar(Jornada jornada)
        {
           Texto txt = new Texto();
           return txt.guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", jornada.ToString());
        }
        public static string Leer(Jornada jornada)
        {
            string aux;
            Texto txt = new Texto();
            txt.leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", out aux);
            return aux;
        }

        #endregion
    }
}
