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

    [Route("api/[controller]")]
    public class TourController : Controller
    {
        // GET api/values/5
        [HttpGet("{longitude}/{latitude}/{theme}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude, string theme)
        {
            return (await new ParisOpenData().GetMovies()).Select(m => SetDistance(m, longitude, latitude)).ToList();
        }

        private MovieScene SetDistance(MovieScene movieScene, double longitude, double latitude)
        {
            var dLat = latitude - movieScene.Latitude;
            var dLont = longitude - movieScene.Longitude;
            var distance = Math.Sqrt(dLat * dLat + dLont * dLont);

            movieScene.Distance = distance;

            return movieScene;
        }
    }
}
