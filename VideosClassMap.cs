using System.Data;
using CsvHelper.Configuration;

namespace Movie_Library_updated
{
    public class VideosClassMap : ClassMap<Videos>
    {
        public VideosClassMap()
        {
            Map(m => m.VideoID).Name("videoId");

            Map(m => m.Title).Name("title");

            Map(m => m.Format).Name("videoFormat");

            Map(m => m.Length).Name("length");

            Map(m => m.Regions).Name("regions");
        }
    }
}