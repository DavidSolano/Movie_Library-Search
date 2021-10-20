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
    public class Videos : Media
    {
        [Name("videoFormat")] public string Format { get; set; }
        [Name("length")] public int Length { get; set; }
        [Name("regions")] public string  Regions { get; set; }

        public override string Display()
        {
            return $"ID: {ID}, Title: {Title}, Format: {Format}, Length: {Length}, Regions: {Regions}";
        }
    }
}