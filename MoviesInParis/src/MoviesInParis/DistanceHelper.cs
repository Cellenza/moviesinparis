using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesInParis
{
    public class DistanceHelper
    {
        public MovieScene SetDistance(MovieScene movieScene, double longitude, double latitude)
        {
            var dLat = latitude - movieScene.Latitude;
            var dLont = longitude - movieScene.Longitude;
            var distance = Math.Sqrt(dLat * dLat + dLont * dLont);

            movieScene.Distance = distance;

            return movieScene;
        }

    }
}
