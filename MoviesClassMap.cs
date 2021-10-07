using CsvHelper.Configuration;
using System.Net.Http.Headers;

namespace Movie_Library_updated
{
    public class MoviesClassMap : ClassMap<Movies>
    {
        public MoviesClassMap()
        {
            Map(m => m.ID).Index(0).Name("movieId");

            Map(m => m.Title).Index(1).Name("title");

            Map(m => m.Genre).Index(2).Name("genres");
        }
    }
}