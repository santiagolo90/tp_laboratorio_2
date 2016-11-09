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
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region Constructores

        public Persona()//constructor con 0 parametros para serializar
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
           this.StringToDNI = dni;//valida el string con la propiedad a int
        }

        #endregion

        #region Propiedades

        public string Apellido
        {
            get {return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); } 
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); } 
        }

        public int DNI 
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this._nacionalidad, value); } //llama al metodo que valida con int
        }
        public ENacionalidad Nacionalidad 
        {
          get{return this._nacionalidad;} 
          set{this._nacionalidad = value;} 
        }
        

        public string StringToDNI//convierte de string a int
        {

            set{ this.DNI = this.ValidarDni(this._nacionalidad, value); }// llama al metodo que valida con string y parsea a int
                 
            
        }

        #endregion

        #region Metodos

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999 || nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato <= 99999999)
            {
                return dato;
            }
            else
            { throw new NacionalidadInvalidaException(); }

            throw new DniInvalidoException();

        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)//parsea el string a int
        {
            int valor = 0;
            valor = int.Parse(dato);
            return valor;
            
        }

        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                //if (char.IsNumber(dato, i))
                if(!char.IsLetter(dato,i))//Si la cadena tiene algun NO char error
                    return "Nombre o Apellido invalido";

                    
            }
            return dato;
        }

        public override string ToString() //Sobrecarga ToString que muestra los datos de la persona
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre Completo: " + this.Apellido + " " + this.Nombre + "\n");
            sb.Append("Nacionalidad: " + this.Nacionalidad.ToString() + "\n");
            //sb.AppendLine("DNI: " + this.DNI);
            return sb.ToString();

        }
        #endregion

    }
}
