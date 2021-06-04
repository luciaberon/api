using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Models
{
    public class Data
    {
        public Data(Articles x, WeatherForecast y)
        {
            this.newsList = x;
            this.weatherFor = y;
        }
        public Articles newsList { get; set; }
        public WeatherForecast weatherFor { get; set; }
    }
}
