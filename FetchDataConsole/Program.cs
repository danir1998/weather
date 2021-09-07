using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FetchDataConsole.Data;
using System.Timers;
using RestSharp;

namespace FetchDataConsole
{
    class Program
    {
        static void Main(string[] args) => init();

        private static void init()
        {
            Timer timer = new Timer();
            timer.Interval = 10000 * Properties.Settings.Default.min;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Console.ReadKey(); //do not close console...
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            saveToDb();
        }

        private static Root fetchData()
        {
            var client = new RestClient(Properties.Settings.Default.api_url + Properties.Settings.Default.api_key);

            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTH:mm:ss.fffZ",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            Root json = JsonConvert.DeserializeObject<Root>(response.Content, settings);

            return json;
        }

        private static void saveToDb()
        {
            Console.WriteLine("Grabbing new data... Hammm....");

            Root dt = fetchData();

            Console.WriteLine("{0} {1} °C {2}", dt.data.city, dt.data.current.weather.tp, dt.data.current.weather.ts);

            using (WeatherEF db = new WeatherEF())
            {
                Weather item = new Weather();
                item.hu = dt.data.current.weather.hu;
                item.tp = dt.data.current.weather.tp;
                item.pr = dt.data.current.weather.pr;
                item.wd = dt.data.current.weather.wd;
                item.ic = dt.data.current.weather.ic;
                item.city = dt.data.city;
                item.state = dt.data.state;
                item.country = dt.data.country;
                item.timestamp = dt.data.current.weather.ts;

                db.Weathers.Add(item);

                if (db.SaveChanges() > 0)
                {
                    Console.WriteLine("New weather saved in the DB =)");
                }
            }

        }


    }
}
