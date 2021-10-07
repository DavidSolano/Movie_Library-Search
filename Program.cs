using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Movie_Library_updated
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            string answer;
            int choice;
            
            //read the file
            Movies movies = new Movies();
            movies.Read();

            do
            {
                menu();
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    try
                    {
                        Console.Write("how many movies would you like to see> ");
                        int view = Convert.ToInt32(Console.ReadLine());

                        foreach (Movies movie in movies.MoviesList.GetRange(0, view))
                        {
                            Console.WriteLine(movie.Display());
                        }
                    }
                    catch (ExternalException e)
                    {
                        logger.Error($"{e} user tried to input a non int value");
                        throw;
                    }
                }else if (choice == 2)
                {
                    try
                    {
                        //asked if it was bad practice to put io in a class method
                        movies.Write();
                    }
                    catch (ExternalException ee)
                    {
                        logger.Error($"{ee} something happened while adding to movie");
                        throw;
                    }
                }else if (choice == 3)
                {
                    Shows shows = new Shows();
                    shows.ReadShows();
                    for (int i = 0; i < shows.showRecords.Count; i++)
                    {
                        Console.WriteLine(shows.showRecords[i].Display());
                    }
                    
                }else if (choice == 4)
                {
                    Videos videos = new Videos();
                    videos.ReadVideos();
                    for (int i = 0; i < videos.VideosList.Count; i++)
                    {
                        Console.WriteLine(videos.VideosList[i].Display());
                    }
                }
                
                Console.WriteLine("would you like to go again? (y/n)");
                answer = Console.ReadLine().ToLower();

            } while (answer == "y");
            
            NLog.LogManager.Shutdown();
        }

        public static void menu()
        {
            Console.WriteLine("enter the number of what you'd like to do");
            Console.WriteLine("1. look for a movie?");
            Console.WriteLine("2. add a movie?");
            Console.WriteLine("3. display shows?");
            Console.WriteLine("4. display videos?");
            Console.Write(">");
        }
    }
}
