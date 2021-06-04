using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using rest_api.Controllers;
using rest_api.Models;

namespace rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet("{city}")]
        public async Task<ActionResult> GetInfo(string city)
        {
   
            using (var client = new HttpClient())
            {
                // url template, parameter: city
                string weatherUrlTemplate = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid=d9851961baf656530f3f0327887479b7";

                // format urls and give its respective parameters
                string urlWeather = string.Format(weatherUrlTemplate, city);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // fetch data: weather
                HttpResponseMessage responseWeather = await client.GetAsync(urlWeather);

                if (responseWeather.IsSuccessStatusCode)
                {
                    // read weather 
                    string jsondataWeather = await responseWeather.Content.ReadAsStringAsync();

                    // deserialize to c# object
                    WeatherForecast weather = JsonSerializer.Deserialize<WeatherForecast>(jsondataWeather);

                    string newsUrlTemplate = "https://newsapi.org/v2/top-headlines?country={0}&apiKey=87637f2cc3b84045a971e158a727c524";
                    string urlNews = string.Format(newsUrlTemplate, weather.sys.country);
                    HttpResponseMessage responseNews = await client.GetAsync(urlNews);

                    if (responseNews.IsSuccessStatusCode)
                    {
                        string jsondataNews = await responseNews.Content.ReadAsStringAsync();
                        Articles news = JsonSerializer.Deserialize<Articles>(jsondataNews);

                        // object that contains news and weather objects
                        Data response = new Data(news, weather);
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonStringResponse = JsonSerializer.Serialize(response, options);

                        // serialize object and return it
                        return Content(jsonStringResponse, "application/json");

                    }
                }
            }
                return NotFound(404);
            }
       
    }

}


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