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


    public sealed class Alumno : PersonaGimnasio
    {

        public enum EEstadoCuenta { Deudor, MesPrueba, AlDia }

        #region atributos y constructores

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()//constructor con 0 parametros para serializar
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ESTADO DE CUENTA: " + this._estadoCuenta + "\n");
            return base.MostrarDatos() + sb.ToString() + ParticiparEnClase() + "\n";
        }

        #region Sobrecargas

        protected override string ParticiparEnClase()// override del abstracto de personaGimnasio
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            bool aux = false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                aux = true;
            if (a._claseQueToma != clase)
                aux= false;

            return aux;
        }
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {return !(a == clase);}
        #endregion
    }
}
