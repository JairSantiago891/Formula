using AdminPlaza.Models.Plaza;
using AdminPlaza.Models.Utils;
using AdminPlaza.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdminPlaza.Common;

namespace AdminPlaza.Models.Plaza
{
    public class PlazaDao
    {
        public List<Plaza> ListaPlaza(Guid? id)
        {
            var list = new List<Plaza>();
            var sql = "SELECT * FROM plaza" + (id == null ? "" : " WHERE plazaId = @id  ");
            var com = AdminDB.ObtenerSqlCommand(sql);
            if (id != null) { 
                com.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                com.Parameters["@id"].Value = id;
            }

            com.CommandTimeout = 8;
            SqlDataReader dr = null;

            try
            {
                com.Connection.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(AdminDB.GetPlaza(dr));
                }
            }

            catch (SqlException ex)
            {
                throw new SqlWebException(WebConstantes.SP_LISTADO);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                if (com.Connection != null)
                    com.Connection.Close();
            }
            return list;

        }


    }
}
