using CsvHelper.Configuration;

namespace Movie_Library_updated
{
    public class ShowsClassMap : ClassMap<Shows>
    {
        public ShowsClassMap()
        {
            Map(m => m.ShowID).Name("showId");

            Map(m => m.Title).Name("title");

            Map(m => m.Season).Name("season");

            Map(m => m.Episode).Name("episode");

            Map(m => m.Writers).Name("writers");
        }
    }
}