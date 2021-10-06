using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Movie_Library_updated
{
    public class Shows
    {
        public List<Shows> ShowsList;
        
        public int ShowID { get; set; }
        public string Title { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public void ReadShows()
        {
            using (var streamReader = new StreamReader(@"Files\\shows.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<ShowsClassMap>();
                    var ShowRecords = csvReader.GetRecords<Shows>().ToList();
                }
            }
        }
    }
}