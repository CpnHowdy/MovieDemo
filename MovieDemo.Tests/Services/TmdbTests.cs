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
            var parsed = Tmdb.ParseTmdbQueryResultsJson(tmdbTestJson);

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

        [TestMethod()]
        public void ParseTmdbDetailsJsonTest()
        {
            var parsed = Tmdb.ParseTmdbDetailsJson(tmdbFightClub);

            // Movie data
            var fightClub = parsed;
            Assert.AreEqual(false, fightClub.Adult);
            Assert.AreEqual(13164, fightClub.Vote_Count);
            Assert.AreEqual(550, fightClub.Id);
            Assert.AreEqual(false, fightClub.Video);
            Assert.AreEqual(8.4, fightClub.Vote_Average);
            Assert.AreEqual("Fight Club", fightClub.Title);
            Assert.AreEqual(30.848, fightClub.Popularity);
            Assert.AreEqual("/adw6Lq9FiC9zjYEpOqfq03ituwp.jpg", fightClub.Poster_path);
            Assert.AreEqual("en", fightClub.Original_Language);
            Assert.AreEqual("Fight Club", fightClub.Original_Title);
            Assert.AreEqual("/87hTDiay2N2qWyX4Ds7ybXi9h8I.jpg", fightClub.Backdrop_Path);
            Assert.AreEqual("A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \"fight clubs\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.", fightClub.Overview);
            Assert.AreEqual(63000000, fightClub.Budget);
            Assert.AreEqual("tt0137523", fightClub.Imdb_Id);
            Assert.AreEqual(100853753, fightClub.Revenue);
            Assert.AreEqual(139, fightClub.Runtime);
            Assert.AreEqual("Released" , fightClub.Status);
            Assert.AreEqual("Mischief. Mayhem. Soap.",
                fightClub.Tagline);

            // Genres
            Assert.AreEqual(1, fightClub.Genres.Count());
            var genre = fightClub.Genres.First();
            Assert.AreEqual(18, genre.Id);
            Assert.AreEqual("Drama", genre.Name);

            // Release date
            var relDate = fightClub.Release_Date.Value;
            Assert.IsNotNull(relDate);
            Assert.AreEqual(1999, relDate.Year);
            Assert.AreEqual(10, relDate.Month);
            Assert.AreEqual(15, relDate.Day);
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

        private readonly string tmdbFightClub = "{\"adult\":false,\"backdrop_path\":\"/87hTDiay2N2qWyX4Ds7ybXi9h8I.jpg\",\"belongs_to_collection\":null,\"budget\":63000000,\"genres\":[{\"id\":18,\"name\":\"Drama\"}],\"homepage\":\"http://www.foxmovies.com/movies/fight-club\",\"id\":550,\"imdb_id\":\"tt0137523\",\"original_language\":\"en\",\"original_title\":\"Fight Club\",\"overview\":\"A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \\\"fight clubs\\\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.\",\"popularity\":30.848,\"poster_path\":\"/adw6Lq9FiC9zjYEpOqfq03ituwp.jpg\",\"production_companies\":[{\"id\":508,\"logo_path\":\"/7PzJdsLGlR7oW4J0J5Xcd0pHGRg.png\",\"name\":\"Regency Enterprises\",\"origin_country\":\"US\"},{\"id\":711,\"logo_path\":\"/tEiIH5QesdheJmDAqQwvtN60727.png\",\"name\":\"Fox 2000 Pictures\",\"origin_country\":\"US\"},{\"id\":20555,\"logo_path\":null, \"name\":\"Taurus Film\",\"origin_country\":\"\"},{\"id\":54051,\"logo_path\":null,\"name\":\"Atman Entertainment\",\"origin_country\":\"\"},{\"id\":54052,\"logo_path\":null,\"name\":\"Knickerbocker Films\",\"origin_country\":\"\"},{\"id\":25,\"logo_path\":\"/qZCc1lty5FzX30aOCVRBLzaVmcp.png\",\"name\":\"20th Century Fox\",\"origin_country\":\"US\"},{\"id\":4700,\"logo_path\":\"/A32wmjrs9Psf4zw0uaixF0GXfxq.png\",\"name\":\"The Linson Company\",\"origin_country\":\"\"}],\"production_countries\":[{\"iso_3166_1\":\"DE\",\"name\":\"Germany\"},{\"iso_3166_1\":\"US\",\"name\":\"United States of America\"}],\"release_date\":\"1999-10-15\",\"revenue\":100853753,\"runtime\":139,\"spoken_languages\":[{\"iso_639_1\":\"en\",\"name\":\"English\"}],\"status\":\"Released\",\"tagline\":\"Mischief. Mayhem. Soap.\",\"title\":\"Fight Club\",\"video\":false,\"vote_average\":8.4,\"vote_count\":13164}";
    }
}