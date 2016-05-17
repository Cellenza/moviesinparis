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
    using MoviesInParis.ImdbData;
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        static TourController()
        {
            var movies = new Dictionary<string, string>()
                             {
                                 { "L'AMOUR C'EST MIEUX A DEUX", "comedie" }, { "TOUT CE QUI BRILLE", "comedie" },
                                 { "L'ARNACOEUR / HEARTBREAKER", "comedie" },
                                 { "LES AVENTURES EXTRAORDINAIRES D'ADELE BLANC SEC", "action" },
                                 { "LES PETITS MOUCHOIRS", "romance" }, { "CAMPING 2", "comedie" },
                                 { "INCEPTION / OLIVER'S ARROW", "action" }, { "TAKEN", "action" },
                                 { "FAUBOURG 36", "action" },
                             };

            moviesFromTheme = (from m in movies group m by m.Value into m2 select m2).ToDictionary(
                m => m.Key,
                m => m.Select(m2 => m2.Key).ToArray());
        }


        // GET api/values/5
        [HttpGet("{longitude}/{latitude}/{theme}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude, string theme)
        {
            var moviesFromTheme = GetMoviesFromTheme(theme);

            var distanceHelper = new DistanceHelper();
            return (await new ParisOpenData().GetMovies())
                .Where(m => moviesFromTheme.Any(m2 => Compare(m.MovieTitle, m2)))
                .Select(m => distanceHelper.SetDistance(m, longitude, latitude))
                .OrderByDescending(m => m.Distance)
                .ToList();
        }

        private bool Compare(string movieTitle, string words)
        {
            var movieTitleLower = movieTitle.ToLower();
            return words.Split(' ').All(m => movieTitleLower.Contains(m));
        }

        private static readonly Dictionary<string, string[]> moviesFromTheme = null;

        private List<string> GetMoviesFromTheme(string theme)
        {
            return moviesFromTheme[theme.ToLower()].ToList();
        }

        //GET api/values/5
        //[HttpGet("imdb/{movieName}")]
        //public async Task<MoviesInParis.> GetImdbMovie(string movieName)
        //{
        //    return (await ImdbOpenData.GetImdbMovie(movieName));
        //}
    }
}
