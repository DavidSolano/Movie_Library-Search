using CsvHelper.Configuration;
using System.Net.Http.Headers;

namespace Movie_Library_updated
{
    public class MoviesClassMap : ClassMap<Movies>
    {
        public MoviesClassMap()
        {
            Map(m => m.MovieID).Name("movieId");

            Map(m => m.Title).Name("title");

            Map(m => m.Genre).Name("genres");
        }
    }
}