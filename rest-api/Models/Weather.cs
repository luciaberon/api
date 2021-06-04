using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class sys
    {
        public string country { get; set; }
    }
    public class WeatherForecast
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }


}
