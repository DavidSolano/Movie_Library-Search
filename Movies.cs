using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Movie_Library_updated
{
    public class Movies : Media
    {
        [Name("genres")] public string Genre { get; set; }

        public override string Display()
        {
            return $"ID: {ID}, Title: {Title}, Genre:{Genre}";
        }
    }
}