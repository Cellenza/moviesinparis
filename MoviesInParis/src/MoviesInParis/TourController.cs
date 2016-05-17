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
        // GET api/values/5
        [HttpGet("{longitude}/{latitude}/{theme}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude, string theme)
        {
            var moviesFromTheme = GetMoviesFromTheme(theme);

            var distanceHelper = new DistanceHelper();
            return (await new ParisOpenData().GetMovies())
                .Where(m=> moviesFromTheme.Any(m2=> Compare(m.MovieTitle, m2)))
                .Select(m => distanceHelper.SetDistance(m, longitude, latitude))
                .OrderByDescending(m => m.Distance)
                .ToList();
        }

        private bool Compare(string movieTitle, string words)
        {
            var movieTitleLower = movieTitle.ToLower(); 
            return  words.Split(' ').All(m => movieTitleLower.Contains(m));
        }

        private Dictionary<string, string[]> moviesFromTheme = new Dictionary<string, string[]>()
                                                                   {
                                                                       {
                                                                           "comedie",
                                                                           new[] { "" }
                                                                       },
                                                                       {
                                                                           "action",
                                                                           new[] { "" }
                                                                       },
                                                                       {
                                                                           "romance",
                                                                           new[] { "" }
                                                                       },
                                                                   };

        private List<string> GetMoviesFromTheme(string theme)
        {
            return this.moviesFromTheme[theme.ToLower()].ToList();
        }

        //GET api/values/5
        //[HttpGet("imdb/{movieName}")]
        //public async Task<MoviesInParis.> GetImdbMovie(string movieName)
        //{
        //    return (await ImdbOpenData.GetImdbMovie(movieName));
        //}
    }
}
