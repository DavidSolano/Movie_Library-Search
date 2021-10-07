using CsvHelper.Configuration;

namespace Movie_Library_updated
{
    public class ShowsClassMap : ClassMap<Shows>
    {
        public ShowsClassMap()
        {
            Map(m => m.ID).Index(0).Name("showId");

            Map(m => m.Title).Index(1).Name("title");

            Map(m => m.Season).Index(2).Name("season");

            Map(m => m.Episode).Index(3).Name("episode");

            Map(m => m.Writers).Index(4).Name("writers");
        }
    }
}