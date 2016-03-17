using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNew.DTO
{
    class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("humidity")]

        public double Humidity { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
    }
}
