using System.Collections.Generic;
using System.IO;
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

        public void ReadShow()
        {
            //deserealize
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
    }
}