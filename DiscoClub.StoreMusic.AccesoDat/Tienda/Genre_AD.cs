using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoClub.StoreMusic.Entidades.Tienda;

namespace DiscoClub.StoreMusic.Negocio.Tienda
{
    public class Genre_AD
    {
        #region VARIABLES
        string str_CnnString = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;
        #endregion

        #region Data Reader
        public Genre LlenarEntidad(IDataReader reader)
        {
            Genre rGenero = new Genre();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GenreID'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["GenreId"]))
                    rGenero.GenreId = Convert.ToInt32(reader["GenreId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Name'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Name"]))
                    rGenero.Name = Convert.ToString(reader["Name"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Description'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Description"]))
                    rGenero.Description = Convert.ToString(reader["Description"]);
            }
            return rGenero;
        }
        #endregion

        public List<Genre> Listar_Generos()
        {
            List<Genre> listaEntidad = new List<Genre>();
            Genre entidad = null;

            using (SqlConnection conexion = new SqlConnection(str_CnnString))
            {
                using (SqlCommand comando = new SqlCommand("usp_listar_generos", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }

        
    }
}
