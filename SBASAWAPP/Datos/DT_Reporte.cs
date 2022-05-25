using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using SBASAWAPP.Models;

namespace SBASAWAPP.Datos
{
    public class DT_Reporte
    {

        public List<ReporteProductos> RetornarProductos()
        {
            List<ReporteProductos> objLista = new List<ReporteProductos>();

            //Data Source=;Initial Catalog= ; User ID= ; Password=
            using (SqlConnection oconexion = new SqlConnection("data source=wdb4.my-hosting-panel.com;initial catalog=example5_SBASAWAPP;user id=example5_ADMIN;password=SistemasDeBombeoArcorSA2022_;MultipleActiveResultSets=True;"))
            {
                string query = "example5_Kendall.SP_RetornarProductos3Meses";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objLista.Add(new ReporteProductos()
                        {
                            name = dr["NAME"].ToString(),
                            cantidad = int.Parse(dr["CANTIDAD"].ToString()),
                        });
                    }
                }
            }

            return objLista;
        }
    }
}