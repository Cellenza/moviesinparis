namespace MoviesInParis.ImdbData
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class ImdbOpenData
    {
        private const string Uri =
            "http://www.omdbapi.com/?y=&plot=short&r=json&t=";

        //public async Task<List<ImdbScene>> GetMovies()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var parisDataString = await client.GetStringAsync(Uri);
        //        var record = JsonConvert.DeserializeObject<ImdbData>(parisDataString);

        //        var movieScenes = from r in record.Records
        //                          select
        //                              new MovieScene()
        //                                  {
        //                                      MovieTitle = r.fields.titre,
        //                                      Longitude = (double)r.fields?.geo_coordinates[0],
        //                                      Latitude = (double)r.fields?.geo_coordinates[1],
        //                                  };

        //        return Enumerable.ToList<MovieScene>(movieScenes);
        //    }
        //}

        public async Task<ImdbScene> GetImdbMovie(string movieName)
        {
            using (var client = new HttpClient())
            {
                string query = string.Format("{0}{1}", Uri, movieName);
                var dataString = await client.GetStringAsync(query);
                var record = JsonConvert.DeserializeObject<ImdbData>(dataString);

                return new ImdbScene() {
                    Title = record.Title,
                    Year = record.Year,
                    Director = record.Director,
                    Genre = record.Genre,
                    Plot = record.Plot,
                    Poster = record.Poster
                };
            }
        }
    }
}