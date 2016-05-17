namespace MoviesInParis
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class MovieScene
    {
        [JsonProperty("movieTitle")]
        public string MovieTitle { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("imdbUrl")]
        public string ImdbUrl { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}