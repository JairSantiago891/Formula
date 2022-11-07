using AdminPlaza.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPlaza.Common
{
    public class SqlWebException : Exception
    {
        public SqlWebException(String mensaje)
            : base(GetMensaje(mensaje))
        {
        }

        public static string GetMensaje(string mensaje)
        {

            string auxMensaje = "";
            if (mensaje.Equals(WebConstantes.SP_LISTADO))
            {
                auxMensaje = "Ocurrio un error al intentar ejecutar la consulta.";
            }
            else if (mensaje.Contains("IX_Roles"))
            {
                auxMensaje = "El Rol ya existe en el Sistema. Favor de verificar los datos ingresados.";
            }
            else if (mensaje.Contains("IX_Usuarios"))
            {
                auxMensaje = "El Usuario ya existe en el Sistema. Favor de verificar los datos ingresados.";
            }
            else if (mensaje.Contains("DELETE"))
            {
                auxMensaje = "El registro tiene relación con otros registros no es porsible eliminarlo.";
            }

            else if (mensaje.Contains("TRABAJADOR_MENOR_EDAD"))
            {
                auxMensaje = "El trabajador es menor de edad.";
            }
            else if (mensaje.Contains("TRABAJADOR_EXISTENTE"))
            {
                auxMensaje = "El trabajador ya esta registrado.";
            }
            else if (mensaje.Contains("NO_TRABAJADOR_EXISTENTE"))
            {
                auxMensaje = "El número de trabajador ya existe.";
            }
            else if (mensaje.Contains("MAXIMO_REINGRESOS"))
            {
                auxMensaje = "El trabajador acumulo el maximo de reingresos";
            }
            else if (mensaje.Contains("NO_CERRAR_JORNADA"))
            {
                auxMensaje = "No se puede cerrar una jornada durante la misma hora.";
            }
            else if (mensaje.Contains("INCIDENCIA_FUERA_DE_RANGO"))
            {
                auxMensaje = "La fecha debe ser mas reciente que la fecha de registro del trabajador.";
            }
            else if (mensaje.Contains("INCIDENCIA_EL_MISMO_DIA"))
            {
                auxMensaje = "Ya existe una incidencia el mismo día.";
            }
            else if (mensaje.Contains("NO_EXISTE_CENTRO_TAYLOR"))
            {
                auxMensaje = "No existe el centro de trabajo Taylor.";
            }
            else if (mensaje.Contains("NUMERO_CUADRILLA_EXISTE"))
            {
                auxMensaje = "Ya existe el número de cuadrilla, asigne uno diferente.";
            }
            else
            {
                return "Error en Base de Datos no controlado, Favor de reportarlo al Administrador del Sistema.";
            }
            return auxMensaje;

        }

    }
}