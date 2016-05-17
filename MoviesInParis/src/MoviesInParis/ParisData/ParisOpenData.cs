namespace MoviesInParis.ParisData
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class ParisOpenData
    {
        private const string Uri =
            "http://opendata.paris.fr/api/records/1.0/search/?dataset=tournagesdefilmsparis2011&facet=realisateur&facet=date_debut_evenement&facet=date_fin_evenement&facet=cadre&facet=lieu&facet=arrondissement";

        public async Task<List<MovieScene>> GetMovies()
        {
            using (var client = new HttpClient())
            {
                var parisDataString = await client.GetStringAsync(Uri);
                var record = JsonConvert.DeserializeObject<ParisData>(parisDataString);

                var movieScenes = from r in record.Records
                                  select
                                      new MovieScene()
                                          {
                                              MovieTitle = r.fields.titre,
                                              Longitude = (double)r.fields?.geo_coordinates[0],
                                              Latitude = (double)r.fields?.geo_coordinates[1],
                                          };

                return Enumerable.ToList<MovieScene>(movieScenes);
            }
        }
    }
}