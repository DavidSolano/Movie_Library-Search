using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Movie_Library_updated
{
    public class Shows : Media
    {
        [Name("season")] public int Season { get; set; }
        [Name("episode")] public int Episode { get; set; }
        [Name("writers")] public string Writers { get; set; }

        public override string Display()
        {
            return $"Title: {Title}, Season: {Season}, Episode: {Episode}, Writers: {Writers}";
        }
        
    }
}