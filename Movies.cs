using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Movie_Library_updated
{
    public class Movies : Media
    {
        public List<Movies> MoviesList;
        
        [Name("genres")] public string Genre { get; set; }
        public void Read()
        {
            using (var streamReader = new StreamReader(@"Files\\movies.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<MoviesClassMap>();
                    MoviesList = csvReader.GetRecords<Movies>().ToList();
                }
            }
        }

        public void Write()
        {
            List<string> temp = new List<string>();
            int last = MoviesList.Count;
            Console.Write("enter movie title> ");
            string newTitle = Console.ReadLine();
            
            Console.Write("how many genres> ");
            int genreAmount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < genreAmount; i++)
            {
                Console.WriteLine("enter the genre");
                temp.Add(Console.ReadLine());
            }

            string newGenre = string.Join('|', temp);
            

            var records = new List<Movies>
            {
                new Movies {ID = last + 1, Title = newTitle, Genre = newGenre}
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
                        csv.Context.RegisterClassMap<MoviesClassMap>();
                        csv.WriteRecords(records);
                    }
                }
            }
        }

        public override string Display()
        {
            return $"{ID} {Title} {Genre}";
        }
    }
}