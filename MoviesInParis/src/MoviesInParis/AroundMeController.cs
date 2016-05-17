using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesInParis
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using MoviesInParis.ImdbData;
    using MoviesInParis.ParisData;

    [Route("api/[controller]")]
    public class AroundMeController : Controller
    {
        // GET api/values/5
        [HttpGet("{longitude}/{latitude}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude)
        {
            var distanceHelper = new DistanceHelper();
            var imdbOpenData = new ImdbOpenData();
            return (await new ParisOpenData().GetMovies())
                  .Select(
                       m =>
                          {
                              var imdb = imdbOpenData.GetImdbMovie(m.MovieTitle).Result;
                              if (imdb != null)
                              {
                                  m.ImdbUrl = imdb.Poster ?? m.ImdbUrl;
                                  m.Director = imdb.Director ?? m.Director;
                                  m.Summary = imdb.Plot ?? m.Summary;
                                  m.Year = imdb.Year ?? m.Year;
                                  m.MovieTitle = imdb.Title ?? m.MovieTitle;
                              }

                              return m;
                          })
                .Select(m => distanceHelper.SetDistance(m, longitude, latitude))
                .OrderBy(m => m.Distance)
                .ToList();
        }
    }
}
