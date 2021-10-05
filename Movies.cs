using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Movie_Library_updated
{
    public class Movies
    {
        public List<Movies> MoviesList;
        
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

        public void Write()
        {
            int last = MoviesList.Count;
            Console.Write("enter movie title> ");
            string newTitle = Console.ReadLine();
            
            Console.Write("enter movie genre> ");
            string newGenre = Console.ReadLine();

            var records = new List<Movies>
            {
                new Movies {MovieID = last + 1, Title = newTitle, Genre = newGenre}
            };
            
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            
            using (var stream = File.Open(@"Files\\movies.csv", FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csv = new CsvWriter(writer, config))
                    {
                        csv.WriteRecords(records);
                    }
                }
            }
        }
    }
}