using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoClub.StoreMusic.Entidades.Tienda;

namespace DiscoClub.StoreMusic.AccesoDat.Tienda
{
    /*Clase que sirve para conectarse a la base de datos debe tener una varia
        variable de conexión a la BD
    */
    public class MusicStoreEntities_AD
    {
        #region VARIABLES
        string str_CnnString = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;
        #endregion
        public List<MusicStoreEntity> ListarGeneroAlbum(string Generonombre)
        {
            //return new List <TipoPersona>();
            List<MusicStoreEntity> listaP = new List<MusicStoreEntity>();
            MusicStoreEntity entidad = new MusicStoreEntity();

            using (SqlConnection conexion = new SqlConnection(str_CnnString))
            {
                using (SqlCommand comando = new SqlCommand("usp_mvcstore_GeneroAlbum_Lst", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombregenero", Generonombre);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {

                        entidad = new MusicStoreEntity();
                        entidad.GenreId = Convert.ToInt32(reader["GenreId"].ToString());
                        entidad.NameGen = reader["NameGen"].ToString();
                        entidad.Description = reader["Description"].ToString();
                        entidad.Title = reader["Title"].ToString();
                        entidad.NameArt = reader["NameArt"].ToString();
                        entidad.Price = Convert.ToDecimal(reader["Price"].ToString());
                        entidad.AlbumId = Convert.ToInt32(reader["AlbumId"].ToString());
                        entidad.ArtistId = Convert.ToInt32(reader["ArtistId"].ToString());

                        listaP.Add(entidad);

                    }
                }
                conexion.Close();
            }
            return listaP;
        }
    }
}
