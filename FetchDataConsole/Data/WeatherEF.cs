using System;
using System.Data.Entity;
using System.Linq;

namespace FetchDataConsole.Data
{
    class WeatherEF : DbContext
    {
        // Контекст настроен для использования строки подключения "WeatherEF" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "FetchDataConsole.Data.WeatherEF" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "WeatherEF" 
        // в файле конфигурации приложения.
        public WeatherEF()
            : base("name=WeatherEF")
        {}

        public DbSet<Weather> Weathers { get; set; }
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}