using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNew.DTO
{
    class WeatherData
    {
        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("coord")]
        public Coord Coordin { get; set; }

        [JsonProperty("wind")]
        public Wind WindInfo { get; set; }
    }
}
