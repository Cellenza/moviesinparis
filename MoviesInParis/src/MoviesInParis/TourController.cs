using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesInParis
{
    using System.Net.Http;

    using MoviesInParis.ParisData;

    using Newtonsoft.Json;
    using ImdbData;
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        
        const string ImdbUri =
            "http://opendata.paris.fr/api/records/1.0/search/?dataset=tournagesdefilmsparis2011&facet=realisateur&facet=date_debut_evenement&facet=date_fin_evenement&facet=cadre&facet=lieu&facet=arrondissement";


        // GET api/values/5
        [HttpGet("{longitude}/{latitude}/{theme}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude, string theme)
        {
            return (await new ParisOpenData().GetMovies()).Select(m => SetDistance(m, longitude, latitude)).ToList();

            //return new List<MovieScene>()
            //           {
            //               new MovieScene()
            //                   {
            //                       MovieTitle = "Inception",
            //                       Distance = 200.0,
            //                       Street = "156 boulevard hausseman",
            //                       ImdbUrl = "http://www.imdb.com/title/tt1985949/?pf_rd_m=A2FGELUUNOQJNL&pf_rd_p=2495768482&pf_rd_r=031VZ78GRDHCT0HKV5K7&pf_rd_s=right-4&pf_rd_t=15061&pf_rd_i=homepage&ref_=hm_otw_t0",
            //                       Photo = "http://ia.media-imdb.com/images/M/MV5BMjMwMjgyMDk0MF5BMl5BanBnXkFtZTgwNDIxOTI4NzE@._V1_UX182_CR0,0,182,268_AL_.jpg"
            //                   },
            //               new MovieScene()
            //                   {
            //                       MovieTitle = "Midnigth in paris",
            //                       Distance = 400.0,
            //                       Street = "156 boulevard hausseman"
            //                   },
            //               new MovieScene()
            //                   {
            //                       MovieTitle = "My movie title",
            //                       Distance = 1000.0,
            //                       Street = "156 boulevard hausseman"
            //                   }
            //           };
        }

        private MovieScene SetDistance(MovieScene movieScene, double longitude, double latitude)
        {
            return movieScene;
        }

        // GET api/values/5
        [HttpGet("imdb/{movieName}")]
        public async Task<ImdbScene> GetImdbMovie(string movieName)
        {
            return (await ImdbOpenData.GetImdbMovie(movieName));
        }
    }
}
