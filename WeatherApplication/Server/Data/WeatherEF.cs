using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApplication.Server.Data
{
    public class WeatherEF : DbContext
    {
        public WeatherEF(DbContextOptions<WeatherEF> options) : base(options)
        { }

        public DbSet<WeatherApplication.Shared.Weather> Weathers { get; set; }
    }
}
