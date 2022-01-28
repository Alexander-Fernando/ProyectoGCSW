using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoClub.StoreMusic.AccesoDat.Tienda;
using DiscoClub.StoreMusic.Entidades.Tienda;

namespace DiscoClub.StoreMusic.Negocio.Tienda
{
    public class Album_LN
    {
        public Album BuscaAlbum(int id)
        {
            try
            {
                return new Album_AD().BuscaAlbum(id);
            }
            catch (Exception v_Ex)
            {
                //Log.Error(v_Ex.Message, v_Ex);
                throw;
            }
        }

        public List<Album> ListaAlbum()
        {
            try
            {
                return new Album_AD().ListaAlbum();
            }
            catch (Exception v_Ex)
            {
                throw;
            }
        }
    }
}
