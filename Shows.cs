using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace Movie_Library_updated
{
    public class Shows : Media
    {
        public List<Shows> showRecords;
        
        [Name("season")] public int Season { get; set; }
        [Name("episode")] public int Episode { get; set; }
        [Name("writers")] public string Writers { get; set; }

        public void ReadShows()
        {
            using (var streamReader = new StreamReader("Files\\shows.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    showRecords = csvReader.GetRecords<Shows>().ToList();
                }
            }
        }

        public override string Display()
        {
            return $"{Title} {Season} {Episode} {Writers}";
        }
    }
}