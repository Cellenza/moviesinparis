namespace MoviesInParis
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MoviesInParis.ImdbData;
    using MoviesInParis.ParisData;

    public class MoviesService
    {
        public async Task<List<MovieScene>> GetMovies(double longitude, double latitude, int take)
        {
            var distanceHelper = new DistanceHelper();
            var imdbOpenData = new ImdbOpenData();
            return
                (await new ParisOpenData().GetMovies()).Select(m => distanceHelper.SetDistance(m, longitude, latitude))
                    .OrderBy(m => m.Distance)
                    .Take(take)
                    .Select(
                        m =>
                            {
                                var imdbData = imdbOpenData.GetImdbMovie(m.MovieTitle).Result;

                                if (imdbData?.title_exact != null && imdbData?.title_exact.Length > 0)
                                {
                                    var imdb = imdbOpenData.GetImdbMovieById(imdbData.title_exact[0].id).Result;
                                    if (imdb != null)
                                    {
                                        m.ImdbUrl = imdb.Poster ?? m.ImdbUrl;
                                        m.Director = imdb.Director ?? m.Director;
                                        m.Summary = imdb.Plot ?? m.Summary;
                                        m.Year = imdb.Year ?? m.Year;
                                        m.MovieTitle = imdb.Title ?? m.MovieTitle;
                                    }
                                }

                                return m;
                            }).ToList();
        }
    }
}