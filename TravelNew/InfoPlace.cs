using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelNew.DTO;

namespace TravelNew
{
    public static class InfoPlace
    {
        public static object a;
        public static int idcountry;
        public static int id;
        public static string placename;
        public static string country;
        public static string capital;
        public static string info_dangerous;
        public static string info_visa;
        public static string info;
        public static string city;
        public static string currency_foreign;
        public static List<ChosenP> cparray = new List<ChosenP>();
        public static List<ChosenP> ccarray = new List<ChosenP>();
        
        public static void SelectingInfo(object a)
        {
            
        }

        public static void WeatherInfo(string APICity, out double latitude, out double longitude, out double speed_wind, out double temp, out double pressure, out double himidity)
        {
            string APIkey = "ac7d30fd6cf00ed0254697b3f4698fb6";
            
            WebClient client = new WebClient();
            var result = client.DownloadString(string.Format("http://api.openweathermap.org/data/2.5/weather?q={1}&units=metric&appid={0}", APIkey, APICity));

            var data = JsonConvert.DeserializeObject<WeatherData>(result);
            latitude =data.Coordin.Latitude;
            longitude= data.Coordin.Longitude;
            speed_wind = data.WindInfo.Speed;
            temp = data.Main.Temperature;
            pressure= data.Main.Pressure;
            himidity = data.Main.Humidity;
        }

        public static void CurrencyInfo()
        {
            string APIkey = "219a7c4cc8020ed17e7b0ee8";

            string amount_currency = "1";
            WebClient client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.exchangerate-api.com/{1}/RUB/{2}?k={0}", APIkey, currency_foreign, amount_currency));
            
            
        }
        
    }
}
