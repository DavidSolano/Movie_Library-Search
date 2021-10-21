using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Movie_Library_updated
{
    class Program
    {
        static void Main(string[] args)
        {
            /*just wanted to say really quickly that
            Justin helped me with this assignment (part of the assignment?)
            (he helped me piece things together. dont quite know the correct verbiage) 
            in case the code looked familiar*/

            string answer;
            int choice;
            
            var logger = NLog.LogManager.GetCurrentClassLogger();

            // used to populate the csv list first to then 
            // be able to send it to json organizer
            IFileHelper fileHelper = new CsvOrganizer();

            //used to copy one list to the other
            JSONOrganizer jsonHelper = new JSONOrganizer();
            
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
                        
                        // reads csv movies list
                        fileHelper.ReadMovie();
                        
                        // copies csv list to json list
                        jsonHelper.MoviesList = (fileHelper as CsvOrganizer).MoviesList;
                        jsonHelper.AddShow();

                        // gets however many movies you want
                        foreach (var movie in jsonHelper.MoviesList.GetRange(0, view))
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
                        // adds the movie
                        fileHelper.AddMovie();
                    }
                    catch (ExternalException ee)
                    {
                        logger.Error($"{ee} something happened while adding to movie");
                        throw;
                    }
                }else if (choice == 3)
                {
                    try
                    {
                        Shows shows = new Shows();
                    
                        // reads shows
                        fileHelper.ReadShow();
                    
                        // adds the shows to .json file
                        jsonHelper.ShowRecords = (fileHelper as CsvOrganizer).ShowRecords;
                        jsonHelper.AddShow();
                    
                        // displays shows
                        shows.Display();
                    }
                    catch (ExternalException e)
                    {
                        logger.Error($"{e} somewhere between copying lists or reading shows went wonky");
                        throw;
                    }
                }else if (choice == 4)
                {
                    try
                    {
                        Videos videos = new Videos();
                    
                        // reads videos in csv
                        fileHelper.ReadVideo();
                    
                        // adds the videos to .json file
                        jsonHelper.VideosList = (fileHelper as CsvOrganizer).VideosList;
                        jsonHelper.AddVideo();
                    
                        // displays videos
                        videos.Display();
                    }
                    catch (ExternalException e)
                    {
                        logger.Error($"{e} somewhere between copying lists or reading videos went wonky");
                        throw;
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
