using System;
using System.Collections.Generic;
//using DiscoClub.StoreMusic.AccesoDat.Tienda;
using DiscoClub.StoreMusic.Entidades.Tienda;


namespace DiscoClub.StoreMusic.Negocio.Tienda
{
    public class Genre_LN
    {
        public List<Genre> Listar_Generos()
        {
            try
            {
                return new Genre_AD().Listar_Generos();
            }
            catch (Exception msg)
            {
                throw msg;
            }
        }
    }
}
