using kakao.Services;
using kakao.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace kakao
{
    public class WeatherForecastQueries
    {
        WeatherService _service;

        public WeatherForecastQueries()
        {
            _service = new WeatherService();
        }

        public async Task<WeatherForecast[]> WeatherForecasts()
        {
            return _service.Get().ToArray();
        }
    }
}
