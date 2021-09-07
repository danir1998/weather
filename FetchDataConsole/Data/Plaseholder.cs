using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchDataConsole.Data
{
    class Plaseholder
    {
    }

    class Location
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    class WeatherBase
    {
        public Nullable<System.DateTime> ts { get; set; }
        public int tp { get; set; }
        public int pr { get; set; }
        public int hu { get; set; }
        public double ws { get; set; }
        public int wd { get; set; }
        public string ic { get; set; }
    }

    class Pollution
    {
        public DateTime ts { get; set; }
        public int aqius { get; set; }
        public string mainus { get; set; }
        public int aqicn { get; set; }
        public string maincn { get; set; }
    }

    class Current
    {
        public WeatherBase weather { get; set; }
        public Pollution pollution { get; set; }
    }

    class Data
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Location location { get; set; }
        public Current current { get; set; }
    }

    class Root
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
}
