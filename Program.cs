using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Movie_Library_updated
{
    class Program
    {
        static void Main(string[] args)
        {
            //read the file and add it to the list
            new Movies().Read();
            
            //display menu
        }
    }
}
