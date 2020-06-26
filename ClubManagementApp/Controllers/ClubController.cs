using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagementApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<IEntityInformation> Get()
        {
            string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            foreach (var summary in Summaries)
                yield return new Entity { Date = DateTime.Now, Summary = summary };
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IEntityInformation Get(Guid id)
        {
            return Get().First();
        }
    }
}
