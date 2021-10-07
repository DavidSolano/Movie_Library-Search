using CsvHelper.Configuration.Attributes;

namespace Movie_Library_updated
{
    public abstract class Media
    {
        [Name("movieId", "showId", "videoId")] public int ID { get; set; }
        
        [Name("title")]public string Title { get; set; }

        public abstract string Display();
    }
}