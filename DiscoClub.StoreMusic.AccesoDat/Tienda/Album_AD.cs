using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DiscoClub.StoreMusic.Entidades.Tienda;

namespace DiscoClub.StoreMusic.AccesoDat.Tienda
{

    public class Album_AD
    {
        #region VARIABLES
        string str_CnnString = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;
        #endregion

        #region Data Reader
        public Album LlenarEntidad(IDataReader reader)
        {
            Album rAlbum = new Album();

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlbumId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["AlbumId"]))
                    rAlbum.AlbumId = Convert.ToInt32(reader["AlbumId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GenreId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["GenreId"]))
                    rAlbum.GenreId = Convert.ToInt32(reader["GenreId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NameGe'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NameGe"]))
                    rAlbum.NameGe = Convert.ToString(reader["NameGe"]);

            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ArtistId'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ArtistId"]))
                    rAlbum.ArtistId = Convert.ToInt32(reader["ArtistId"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NameAr'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NameAr"]))
                    rAlbum.NameAr = Convert.ToString(reader["NameAr"]);
            }


            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Title'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Title"]))
                    rAlbum.Title = Convert.ToString(reader["Title"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Price'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Price"]))
                    rAlbum.Price = Convert.ToInt32(reader["Price"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlbumArtUrl'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["AlbumArtUrl"]))
                    rAlbum.AlbumArtUrl = Convert.ToString(reader["AlbumArtUrl"]);
            }

            return rAlbum;
        }
        #endregion

        public Album BuscaAlbum(int id)
        {
            Album AlbumEntidad = new Album();
            using (SqlConnection conexion = new SqlConnection(str_CnnString))
            {
                using (SqlCommand comando = new SqlCommand("usp_mvcstore_Album_Busca", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);
                    comando.Parameters.AddWithValue("@idAlb", id);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        AlbumEntidad = LlenarEntidad(reader);
                    }
                }
                conexion.Close();
            }
            return AlbumEntidad;
        }

        public List<Album> ListaAlbum()
        {
            List<Album> ListaAlb = new List<Album>();
            Album Entidad = new Album();

            using (SqlConnection conexion = new SqlConnection(str_CnnString))
            {
                using (SqlCommand comando = new SqlCommand("usp_mvcstore_Album_Lista", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["Timeout_AccessData"]);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {

                        Entidad = LlenarEntidad(reader);
                        ListaAlb.Add(Entidad);

                    }
                }
                conexion.Close();
            }
            return ListaAlb;
        }

    }
}
