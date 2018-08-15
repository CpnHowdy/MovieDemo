using MovieDemo.Interfaces;
using MovieDemo.Models;
using MovieDemo.Services;
using MovieDemo.Util;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace MovieDemo.Controllers
{
    [Authorize]
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

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t">TMDB ID of movie to be added</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMovie(int t)
        {
            var userId = User.Identity.GetUserId();
            _tmdb.AddMovie(t, userId);

            return new JsonResult() {  };
        }
    }
}