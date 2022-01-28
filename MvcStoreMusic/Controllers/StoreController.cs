using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiscoClub.StoreMusic.Negocio.Tienda;
using DiscoClub.StoreMusic.Entidades.Tienda;
using DiscoClub.StoreMusic.Negocio;


namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {//
     // GET: /Store/
        public ActionResult Index()
        {

            List<Genre> genres = new List<Genre>();

            genres = new Genre_LN().Listar_Generos();

            return View(genres);
 

        }

        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string genero)
        {
            List<MusicStoreEntity> genreModel = new List<MusicStoreEntity>();
            genreModel = new MusicStoreEntities_LN().ListarGeneroAlbum(genero);
            // var genreModel = new Genre { Name = genre };
            return View(genreModel);
        }

        
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            Album album = new Album();
            album = new Album_LN().BuscaAlbum(id);
            return View(album);
        }
    }
}