using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Movie_Library_updated
{
    class Program
    {
        static void Main(string[] args)
        {
            Addcsvtolist();
        }

        public static void Addcsvtolist()
        {
            using (var streamReader = new StreamReader(@"Files\\movies.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<MoviesClassMap>();
                    var records = csvReader.GetRecords<dynamic>().ToList();
                }
            }
        }
    }
}
