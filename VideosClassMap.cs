using System.Data;
using CsvHelper.Configuration;

namespace Movie_Library_updated
{
    public class VideosClassMap : ClassMap<Videos>
    {
        public VideosClassMap()
        {
            Map(m => m.ID).Index(0).Name("videoId");

            Map(m => m.Title).Index(1).Name("title");

            Map(m => m.Format).Index(2).Name("videoFormat");

            Map(m => m.Length).Index(3).Name("length");

            Map(m => m.Regions).Index(4).Name("regions");
        }
    }
}