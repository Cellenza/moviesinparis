using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesInParis
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using MoviesInParis.ParisData;

    [Route("api/[controller]")]
    public class AroundMeController : Controller
    {
        // GET api/values/5
        [HttpGet("{longitude}/{latitude}")]
        public async Task<List<MovieScene>> Get(double longitude, double latitude)
        {
            var distanceHelper = new DistanceHelper();
            return (await new ParisOpenData().GetMovies())
                .Select(
                    m =>
                        {
                            m.ImdbUrl =
                                "http://www.imdb.com/title/tt1985949/?pf_rd_m=A2FGELUUNOQJNL&pf_rd_p=2495768482&pf_rd_r=19Z6EK3TTTY0HMFCARH3&pf_rd_s=right-4&pf_rd_t=15061&pf_rd_i=homepage&ref_=hm_otw_t0";
                            m.Photo =
                                "http://ia.media-imdb.com/images/M/MV5BMjMwMjgyMDk0MF5BMl5BanBnXkFtZTgwNDIxOTI4NzE@._V1_UX182_CR0,0,182,268_AL_.jpg";
                            return m;
                        })
                .Select(m => distanceHelper.SetDistance(m, longitude, latitude))
                .OrderByDescending(m => m.Distance)
                .ToList();
        }
    }
}
