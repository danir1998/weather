using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Server.Data;
using WeatherApplication.Shared;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        WeatherEF db;

        public WeatherController(WeatherEF context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Weather>> Get()
        {
            return await db.Weathers.OrderByDescending(x => x.id).ToListAsync();
        }

        [HttpGet("last/")]
        public async Task<Weather> Last()
        {
            return await db.Weathers.OrderByDescending(x => x.id).Take(1).FirstOrDefaultAsync();
        }


        [HttpGet("date/{date1}/{date2}")]
        public async Task<IEnumerable<Weather>> Date(string date1 = "", string date2 = "")
        {
            var date_start = DateTime.Parse(date1).AddDays(-1);
            var date_end = DateTime.Parse(date2);

            return await db.Weathers.Where(x => x.timestamp >= date_start && x.timestamp <= date_end).ToListAsync();
        }
    }
}
