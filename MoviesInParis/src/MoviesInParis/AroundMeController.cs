using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesInParis
{
    [Route("api/[controller]")]
    public class AroundMeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{longitude}/{latitude}")]
        public List<MovieScene> Get(double longitude, double latitude)
        {
            return new List<MovieScene>()
                       {
                           new MovieScene()
                               {
                                   MovieTitle = "Inception",
                                   Distance = 200.0,
                                   Street = "156 boulevard hausseman"
                               },
                           new MovieScene()
                               {
                                   MovieTitle = "Midnigth in paris",
                                   Distance = 400.0,
                                   Street = "156 boulevard hausseman"
                               },
                           new MovieScene()
                               {
                                   MovieTitle = "My movie title",
                                   Distance = 1000.0,
                                   Street = "156 boulevard hausseman"
                               }
                       };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
