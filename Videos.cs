using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Movie_Library_updated
{
    public class Videos
    {
        public List<Videos> VideosList;
        
        public int VideoID { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public void ReadVideos()
        {
            using (var streamReader = new StreamReader(@"Files\\videos.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<VideosClassMap>();
                    var records = csvReader.GetRecords<Videos>().ToList();
                }
            }
        }
    }
}