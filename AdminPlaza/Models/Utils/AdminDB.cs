using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Data;

namespace AdminPlaza.Models.Utils
{
    public class AdminDB
    {
        public enum typeDBSystem
        {
            WEBDB
        }
        public static SqlConnection getConnection(typeDBSystem type)
        {
            SqlConnection cnx;
            string scnx;
            switch (type)
            {
                case typeDBSystem.WEBDB:
                    scnx = WebConfigurationManager.ConnectionStrings["GrupoFormulaAWS"].ConnectionString;
                    break;
                default:
                    scnx = null;
                    break;
            }
            if (scnx != null)
                cnx = new SqlConnection(scnx);
            else
                return null;
            return cnx;
        }

        public static SqlParameter ObtenerTotalRecordsParam(ref SqlCommand com)
        {
            SqlParameter totalRecords = new SqlParameter(WebConstantes.PARAM_TOTALRECORDS, 0);
            totalRecords.Direction = ParameterDirection.Output;
            com.Parameters.Add(totalRecords);
            return totalRecords;
        }

        public static SqlCommand ObtenerSqlCommand(string query)
        {
            SqlConnection conn = AdminDB.getConnection(AdminDB.typeDBSystem.WEBDB);
            SqlCommand com = new SqlCommand(query, conn);            
            return com;
        }


        public static Models.Plaza.Plaza GetPlaza(SqlDataReader dr )
        {
            //var dt = dr.GetSchemaTable().Rows["ColumnName];
            //foreach (DataRow element in dt)
            //{
            //    var e = dt[0].Table;
            //}
            bool hasColumnName = dr.GetSchemaTable().Columns[0] == null;
            return new Models.Plaza.Plaza
            {
                PlazaId = (Guid)dr["PlazaId"],
                NombrePlaza = (string)dr["NombrePlaza"],
                NombreCorto = (string)dr["NombreCorto"],
                NombreDirector = (string)dr["NombreDirector"],
                TelefonoDirector = (string)dr["TelefonoDirector"],
                CorreoDirector = (string)dr["CorreoDirector"],
                NombreIngeniero = (string)dr["NombreIngeniero"],
                TelefonoIngeniero = (string)dr["TelefonoIngeniero"],
                CorreoIngeniero = (string)dr["CorreoIngeniero"],
                PlazaActiva = (bool)dr["PlazaActiva"],
                Logo =  (dr["Logo"] == null || !hasColumnName) ? null : (byte[])dr["Logo"]
            };
        }
    }
}