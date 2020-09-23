using kakao.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kakao.Services
{
    public class WeatherService
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool",
            "Mild", "Warm", "Balmy", "Hot",
            "Sweltering", "Scorching"
        };

        private static readonly DateTime basicDate = new DateTime(2020, 1, 1);

        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Summaries.Select((s, index) => new WeatherForecast
            {
                Date = basicDate.AddDays(index),
                TemperatureC = s.Length * 2,
                Summary = s
            });
        }
    }
}
