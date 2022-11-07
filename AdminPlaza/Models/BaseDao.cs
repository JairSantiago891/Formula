using AdminPlaza.Common;
using AdminPlaza.Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AdminPlaza.Models
{
    public class BaseDao
    {
        /// <summary>
        /// Total de registros
        /// </summary>
        public long totalRecords { get; set; }

        public string ObtenerValor(string nombreColumna, SqlDataReader dr)
        {
            if (dr[nombreColumna] == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)dr[nombreColumna];
            }
        }
        /// <summary>
        /// Obtiene MySqlCommand
        /// </summary>
        /// <param name="nombreStoredProcedure"></param>
        /// <returns></returns>
        public SqlCommand ObtenerSqlCommand(string nombreStoredProcedure)
        {
            SqlConnection conn = AdminDB.getConnection(AdminDB.typeDBSystem.WEBDB);
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = nombreStoredProcedure;
            return com;
        }
        /// <summary>
        /// Obtiene el parametro TotalRecords
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public SqlParameter ObtenerTotalRecordsParam(ref SqlCommand com)
        {
            SqlParameter totalRecords = new SqlParameter(WebConstantes.PARAM_TOTALRECORDS, 0);
            totalRecords.Direction = ParameterDirection.Output;
            com.Parameters.Add(totalRecords);
            return totalRecords;
        }
        public static DataTable ObtenerTableData<obj>(List<obj> ListObj)
        {
            if (ListObj == null)
                return null;
            DataTable dataTable = new DataTable();
            Assembly assembly = Assembly.GetExecutingAssembly();
            PropertyInfo[] Types = typeof(obj).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int j = 0;
            Type typedata = null;
            string[] PropNoms = new string[Types.Length];
            foreach (PropertyDescriptor descpTypes in TypeDescriptor.GetProperties(typeof(obj)))
            {

                /// Propiedades con tipo de dato del Systema : Int, Long, String, DateTime, etc. Se obtiene su nombre y tipo de Dato.
                if (descpTypes.PropertyType.Namespace == "System")
                {
                    var nombre = descpTypes.Name;
                    PropNoms[j] = nombre;

                    if (descpTypes.PropertyType == typeof(long?))
                        typedata = typeof(long);
                    else if (descpTypes.PropertyType == typeof(decimal?))
                        typedata = typeof(decimal);
                    else if (descpTypes.PropertyType == typeof(DateTime?))
                        typedata = typeof(DateTime);
                    else if (descpTypes.PropertyType == typeof(DateTimeOffset?))
                        typedata = typeof(DateTimeOffset);
                    else if (descpTypes.PropertyType == typeof(int?))
                        typedata = typeof(int);
                    else
                        typedata = descpTypes.PropertyType;

                }
                ///Propiedades con Tipo de dato (webGPS_Clase). Se obtiene el nombre de su Identificador y su Tipo de Dato.
                else
                {
                    var subobj = AppDomain.CurrentDomain.CreateInstance(assembly.FullName, descpTypes.PropertyType.FullName);
                    PropertyInfo[] SubTypes = subobj.Unwrap().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    int k = 0;
                    foreach (PropertyInfo subtype in SubTypes)
                    {
                        if (k == 0)
                        {
                            var nombre = subtype.Name;
                            var nC = 0;
                            foreach (string nom in PropNoms)
                            {
                                if (nom != null && nom.Contains(nombre))
                                    nC++;
                            }
                            if (nC > 0)
                                nombre = nombre + nC.ToString();

                            PropNoms[j] = nombre;
                            if (subtype.PropertyType == typeof(long?))
                                typedata = typeof(long);
                            else if (subtype.PropertyType == typeof(int?))
                                typedata = typeof(int);
                            else
                                typedata = subtype.PropertyType;
                        }
                        k++;
                    }
                }


                dataTable.Columns.Add(PropNoms[j], typedata);
                j++;
            }
            foreach (obj item in ListObj)
            {
                var values = new object[PropNoms.Length];
                for (int i = 0; i < PropNoms.Length; i++)
                {
                    if (Types[i].PropertyType.Namespace == "System")
                        values[i] = Types[i].GetValue(item, null);
                    else
                    {
                        var subobj = AppDomain.CurrentDomain.CreateInstance(assembly.FullName, Types[i].PropertyType.FullName);
                        PropertyInfo[] SubTypes = subobj.Unwrap().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        if (Types[i].GetValue(item, null) == null)
                        {
                            values[i] = null;
                        }
                        else
                        {
                            values[i] = SubTypes[0].GetValue(Types[i].GetValue(item, null), null);
                        }
                    }
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;


        }

    }
}