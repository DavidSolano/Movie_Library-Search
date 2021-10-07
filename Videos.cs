using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace Movie_Library_updated
{
    public class Videos : Media
    {
        public List<Videos> VideosList;
        
        [Name("videoFormat")] public string Format { get; set; }
        [Name("length")] public int Length { get; set; }
        [Name("regions")] public int Regions { get; set; }

        public void ReadVideos()
        {
            using (var streamReader = new StreamReader(@"Files\\videos.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    VideosList = csvReader.GetRecords<Videos>().ToList();
                }
            }
        }

        public override string Display()
        {
            return $"{ID} {Title} {Format} {Length} {Regions}";
        }
    }
}