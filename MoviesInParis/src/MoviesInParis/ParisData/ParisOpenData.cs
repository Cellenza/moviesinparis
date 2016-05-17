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
            "http://opendata.paris.fr/api/records/1.0/search/?dataset=tournagesdefilmsparis2011&rows=9999&facet=realisateur&facet=date_debut_evenement&facet=date_fin_evenement&facet=cadre&facet=lieu&facet=arrondissement";

        private static List<MovieScene> movies = null;

        public async Task<List<MovieScene>> GetMovies()
        {
            if (movies == null)
            {

                using (var client = new HttpClient())
                {
                    var parisDataString = await client.GetStringAsync(Uri);
                    var record = JsonConvert.DeserializeObject<ParisData>(parisDataString);

                    var movieScenes = from r in record.Records
                                      select
                                          new MovieScene()
                                          {
                                              MovieTitle = GetTitle(r),
                                              Director = r.fields.realisateur,
                                              Longitude = GetLongitude(r),
                                              Latitude = GetLatitude(r),
                                              Street = r.fields.adresse_complete,
                                          };
                    movies = movieScenes.ToList();
                }
            }

            return movies;
        }

        private static string GetTitle(ParisRecord r)
        {
            if (r.fields.titre.Contains("/"))
            {
                return r.fields.titre.Split('/')[0].Trim();
            }

            return r.fields.titre.Trim();
        }

        private static double GetLatitude(ParisRecord r)
        {
            if (r.fields.geo_coordinates != null)
            {
                return r.fields.geo_coordinates[1];
            }

            return 0;
        }

        private static double GetLongitude(ParisRecord r)
        {
            if (r.fields.geo_coordinates != null)
            {
                return r.fields.geo_coordinates[0];
            }

            return 0;
        }
    }
}