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
        private readonly MoviesService moviesService = new MoviesService();

        // GET api/values/5
        [HttpGet("{longitude}/{latitude}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude)
        {
            var moviesService = new MoviesService();
            return await moviesService.GetMovies(longitude, latitude, 100);
        }
    }
}
