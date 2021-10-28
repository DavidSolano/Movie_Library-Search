using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using Newtonsoft.Json;

namespace Movie_Library_updated
{
    public class JSONOrganizer : IFileHelper
    {
        public List<Movies> MoviesList = new List<Movies>();
        public List<Shows> ShowRecords = new List<Shows>();
        public List<Videos> VideosList = new List<Videos>();
        
        
        public JSONOrganizer()
        {
            string text = File.ReadAllText(@"Files\\videos.json");
            VideosList = JsonConvert.DeserializeObject<List<Videos>>(text);
        }

        //reading is the deserializing
        public void ReadShow()
        {
            string text = File.ReadAllText(@"Files\\shows.json");
            ShowRecords = JsonConvert.DeserializeObject<List<Shows>>(text);
        }

        public void ReadMovie()
        {
            string MovieText = File.ReadAllText(@"Files\\movies.json");
            MoviesList = JsonConvert.DeserializeObject<List<Movies>>(MovieText);
        }

        public void ReadVideo()
        {
            string text = File.ReadAllText(@"Files\\videos.json");
            VideosList = JsonConvert.DeserializeObject<List<Videos>>(text);
        }

        //adding is the same is serializing
        public void AddMovie()
        {
            string data;
            data = JsonConvert.SerializeObject(MoviesList, Formatting.Indented);
            File.WriteAllText(@"Files\\movies.json", data);
        }

        public void AddShow()
        {
            string data;
            data = JsonConvert.SerializeObject(ShowRecords, Formatting.Indented);
            File.WriteAllText(@"Files\\shows.json", data);
        }

        public void AddVideo()
        {
            string data;
            data = JsonConvert.SerializeObject(VideosList, Formatting.Indented);
            File.WriteAllText(@"Files\\videos.json", data);
        }

        public void Search()
        {
            Console.WriteLine("enter the title");
            string title = Console.ReadLine().ToLower();

            var movies = MoviesList.Where(x => x.Title.ToLower().Contains(title)).ToList();
            movies.ForEach(l => Console.WriteLine(l.Display()));




            var shows = ShowRecords.Where(y => y.Title.ToLower().Contains(title)).ToList();
            shows.ForEach(n => Console.WriteLine(n.Display()));
            


            var videos = VideosList.Where(z => z.Title.ToLower().Contains(title)).ToList();
            videos.ForEach(h => Console.WriteLine(h.Display()));
        }
    }
}