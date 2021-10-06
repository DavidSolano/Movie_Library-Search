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
            //read the file
            Movies movies = new Movies();
            movies.Read();

            //display menu
        }


        public static void menu()
        {
            Console.WriteLine("enter the number of what you'd like to do");
            Console.WriteLine("1. look for a movie?");
            Console.WriteLine("2. add a movie?");
            
        }
    }
}
