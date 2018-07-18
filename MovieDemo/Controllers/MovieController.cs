using MovieDemo.Interfaces;
using MovieDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDemo.Controllers
{
    public class MovieController : Controller
    {
        private readonly IOmdb _omdb;

        public MovieController(IOmdb omdb)
        {
            _omdb = omdb;
        }

        public MovieController()
        {
            _omdb = new Omdb();
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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult QueryImdbId(string imdbId)
        {
            var dataFound = _omdb.QueryTitle(imdbId);

            var toReturn = new JsonResult();
            toReturn.Data = dataFound;
            return toReturn;
        }
    }
}