using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoClub.StoreMusic.Entidades.Tienda;
using DiscoClub.StoreMusic.AccesoDat.Tienda;

namespace DiscoClub.StoreMusic.Negocio.Tienda
{
    public class MusicStoreEntities_LN
    {
        public List<MusicStoreEntity> ListarGeneroAlbum(string genero)
        {
            try {
                return new MusicStoreEntities_AD().ListarGeneroAlbum(genero);

            }
            catch (Exception v_Ex)
            {
                throw;
            }
        }
    }
}
