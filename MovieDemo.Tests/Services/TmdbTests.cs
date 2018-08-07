using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDemo.Services.Tests
{
    [TestClass()]
    public class TmdbTests
    {
        [TestMethod()]
        public void ParseTmdbJsonTest()
        {
            var parsed = Tmdb.ParseTmdbJson(tmdbTestJson);

            // High-level data
            Assert.AreEqual(1, parsed.Page);
            Assert.AreEqual(1, parsed.Total_Results);
            Assert.AreEqual(1, parsed.Total_Pages);
            Assert.AreEqual(parsed.Results.Count, 1);

            // Movie data
            var deepPurple = parsed.Results[0];
            Assert.AreEqual(false, deepPurple.Adult);
            Assert.AreEqual(3, deepPurple.Vote_Count);
            Assert.AreEqual(66012, deepPurple.Id);
            Assert.AreEqual(false, deepPurple.Video);
            Assert.AreEqual(5.5, deepPurple.Vote_Average);
            Assert.AreEqual("Deep Purple: Come Hell or High Water", deepPurple.Title);
            Assert.AreEqual(0.795, deepPurple.Popularity);
            Assert.AreEqual("/7csw5STUJBmKpl4hIvgRyz24Y2d.jpg", deepPurple.Poster_path);
            Assert.AreEqual("en", deepPurple.Original_Language);
            Assert.AreEqual("Deep Purple: Come Hell or High Water", deepPurple.Original_Title);
            Assert.AreEqual("/sOq3vmvdDnZ15vHwP0Gg5Jwa7Tf.jpg", deepPurple.Backdrop_Path);
            Assert.AreEqual("Rock legend Deep Purple recorded live at the Birmingham NEC, UK on November 9, 1993. Five members from the band's most famous line up play their hits during their 25th anniversary world tour. Note that Ritchie Blackmore dropped out soon after this particular concert.", deepPurple.Overview);

            // Release date
            var relDate = deepPurple.Release_Date.Value;
            Assert.IsNotNull(relDate);
            Assert.AreEqual(1993, relDate.Year);
            Assert.AreEqual(11, relDate.Month);
            Assert.AreEqual(16, relDate.Day);

            // Genre id's
            var genreIds = deepPurple.Genre_Ids;
            Assert.IsNotNull(genreIds);
            Assert.AreEqual(1, genreIds.Length);
            Assert.AreEqual(genreIds[0], 10402);
        }

        private Tmdb _tmdb { get; set; }
        public Tmdb Tmdb
        {
            get
            {
                if (_tmdb == null)
                    _tmdb = new Tmdb();
                return _tmdb;
            }
            set
            {
                _tmdb = value;
            }
        }

        private readonly string tmdbTestJson = "{\"page\":1,\"total_results\":1,\"total_pages\":1,\"results\":[{\"vote_count\":3,\"id\":66012,\"video\":false,\"vote_average\":5.5,\"title\":\"Deep Purple: Come Hell or High Water\",\"popularity\":0.795,\"poster_path\":\"\\/7csw5STUJBmKpl4hIvgRyz24Y2d.jpg\",\"original_language\":\"en\",\"original_title\":\"Deep Purple: Come Hell or High Water\",\"genre_ids\":[10402],\"backdrop_path\":\"\\/sOq3vmvdDnZ15vHwP0Gg5Jwa7Tf.jpg\",\"adult\":false,\"overview\":\"Rock legend Deep Purple recorded live at the Birmingham NEC, UK on November 9, 1993. Five members from the band's most famous line up play their hits during their 25th anniversary world tour. Note that Ritchie Blackmore dropped out soon after this particular concert.\",\"release_date\":\"1993-11-16\"}]}";
    }
}