using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Movie_Library_updated
{
    public class CsvOrganizer : IFileHelper
    {
        public List<Movies> MoviesList = new List<Movies>();
        public List<Shows> ShowRecords;
        public List<Videos> VideosList;

        public void ReadShow()
        {
            
            using (var streamReader = new StreamReader("Files\\shows.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    ShowRecords = csvReader.GetRecords<Shows>().ToList();
                }
            }

            foreach (var shows in ShowRecords)
            {
                Console.WriteLine(shows.Display());
            }
        }

        public void ReadMovie()
        {
            using (var streamReader = new StreamReader(@"Files\\movies.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<MoviesClassMap>();
                    MoviesList = csvReader.GetRecords<Movies>().ToList();
                }
            }

            foreach (var movie in MoviesList)
            {
                Console.WriteLine(movie.Display());
            }
        }

        public void ReadVideo()
        {
            using (var streamReader = new StreamReader(@"Files\\videos.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    VideosList = csvReader.GetRecords<Videos>().ToList();
                }
            }

            foreach (var videos in VideosList)
            {
                Console.WriteLine(videos.Display());
            }
        }

        public void AddMovie()
        {
            //updates the list
            using (var streamReader = new StreamReader(@"Files\\movies.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<MoviesClassMap>();
                    MoviesList = csvReader.GetRecords<Movies>().ToList();
                }
            }
            
            
            List<string> temp = new List<string>();
            int last = MoviesList.Count + 1;
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
                new Movies {ID = last, Title = newTitle, Genre = newGenre}
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

        public void AddShow()
        {
            throw new NotImplementedException();
        }

        public void AddVideo()
        {
            throw new NotImplementedException();
        }
    }
}