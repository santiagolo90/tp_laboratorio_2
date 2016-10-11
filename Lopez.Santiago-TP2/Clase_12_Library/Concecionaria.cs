﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;//Agregue using del namespace de vehiculo

namespace Clase_12_Library
{
    public class Concecionaria //quite abstract para instanciar 
    {
        List<Vehiculo> _vehiculos;
        int _espacioDisponible;
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }

        #region "Constructores"
        private Concecionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        public Concecionaria(int espacioDisponible):this() //llamar al contructor con 0 parametros
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()//override para pisar el metodo padre
        {
           // return Concecionaria.Mostrar(this, ETipo.Todos);
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                switch (tipoDeVehiculo)//se agrega validacion por cantidad de ruedas 
                {
                    case ETipo.Automovil:
                        if( v.CantidadRuedas == 4)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if(v.CantidadRuedas == 2)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Camion:
                        if(v.CantidadRuedas == 8)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();//Agregue ToString
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concecionaria operator +(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            if (concecionaria._vehiculos.Count >= concecionaria._espacioDisponible)
                return concecionaria;

            foreach (Vehiculo v in concecionaria._vehiculos)//agregue concecionaria._vehiculos
            {
                if (v == vehiculo)
                    return concecionaria;
            }

            concecionaria._vehiculos.Add(vehiculo);
            return concecionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in concecionaria._vehiculos)//agregue concecionaria._vehiculos
            {
                if (v == vehiculo)
                {
                    concecionaria._vehiculos.Remove(v);
                    break;
                }
            }

            return concecionaria;
        }
        #endregion
    }
}
