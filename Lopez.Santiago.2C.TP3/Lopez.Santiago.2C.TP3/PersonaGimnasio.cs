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


namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {
        #region Atributo y constructor
        private int _identificador;

        public PersonaGimnasio()
        { }//constructor con 0 parametros para serializar

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)

        {
            this._identificador = id;
        }

        #endregion

        #region Sobrecargas

        public override bool Equals(object obj)//si el tipo del obj es igual al tipo actual = True
        {
            if (this.GetType() == obj.GetType())
                return true;
            else
                return false;
            //if (obj is PersonaGimnasio)
            //    return true;
            //else
            //    return false;
        }

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            
                if (pg1.Equals(pg2) && pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador)
                    return true;
                else
                    return false;

        }
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        { return !(pg1 == pg2); }

        #endregion

        #region metodos
        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()//Sobrecarga ToString que muestra los datos de la persona
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nCARNET NUMERO: " + this._identificador);
            return base.ToString() + sb.ToString();
        }

        #endregion

    }
}
