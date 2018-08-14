using MovieDemo.Interfaces;
using MovieDemo.Models;
using MovieDemo.Services;
using MovieDemo.Util;
using System.Web.Mvc;

namespace MovieDemo.Controllers
{
    public class MovieController : Controller
    {
        private readonly IOmdb _omdb;
        private readonly ITmdb _tmdb;

        private ConfigFetcher _configFetcher { get; set; }
        public ConfigFetcher ConfigFetcher
        {
            get
            {
                if (_configFetcher == null)
                    _configFetcher = new ConfigFetcher();
                return _configFetcher;
            }
        }

        public MovieController(IOmdb omdb, ITmdb tmdb)
        {
            _omdb = omdb;
            _tmdb = tmdb;
        }

        public MovieController()
        {
            _omdb = new Omdb();
            _tmdb = new Services.Tmdb();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult QueryImdbId(string imdbId)
        //{
        //    var dataFound = _omdb.QueryImdbId(imdbId);

        //    var toReturn = new JsonResult
        //    {
        //        Data = dataFound
        //    };
        //    return toReturn;
        //}

        /// <summary>
        ///     
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="imdbId"></param>
        /// <returns></returns>
        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult QueryImdbId(int? movieId, string imdbId)
        //{
        //    var movieFound = _omdb.QueryImdbId(imdbId);
        //    var viewModel = new MovieDetailsViewModel(movieFound);
            
        //    return View(viewModel);
        //}

        /// <summary>
        ///     
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="imdbId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Search(string q)
        {
            var movieFound = _tmdb.Search(q);
            var viewModel = new MovieSearchViewModel(movieFound);

            // TODO: convert to ImageSizeFetcher
            var posterSize = Util.Tmdb.IMAGE_SIZES.W92.ToString().ToLower();
            viewModel.PosterPath = $"{ConfigFetcher.Fetch(Config.TMDB_IMAGE_URL)}/{posterSize}/";
            return View(viewModel);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="imdbId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Detail(int id)
        {
            var movieFound = _tmdb.Details(id, Util.Tmdb.IMAGE_SIZES.W154.ToString().ToLower());
            var viewModel = new MovieDetailsViewModel(movieFound);

            return View(viewModel);
        }
    }
}