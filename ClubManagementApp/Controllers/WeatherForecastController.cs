using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClubManagementApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController<T> : ControllerBase where T : IEntityInformation, new()
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController<T>> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController<T>> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<T> Get()
        {
            foreach(var summary in Summaries)
                yield return new T { Date = DateTime.Now, Summary = summary };
        }

        [HttpGet]
        public T Get(Guid id)
        {
            return new T();
        }
    }
}
