using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Movie_Library_updated
{
    public class Movies
    {
        public int MovieID { get; set; }
        
        public string Title { get; set; }
        
        public string Genre { get; set; }

        public void Read()
        {
            using (var streamReader = new StreamReader(@"Files\\movies.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<MoviesClassMap>();
                    var records = csvReader.GetRecords<Movies>().ToList();
                }
            }
        }
    }
}