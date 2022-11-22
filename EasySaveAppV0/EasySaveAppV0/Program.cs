using System;
using System.IO;
using EasySaveAppV0.SearchFile;

namespace EasySaveAppV0
{    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EasySave.v1 - Make your choice");
            Choice();
        }
        public static void Choice()
        { 
            Console.WriteLine("1.  Create a save");
            Console.WriteLine("2.  Read the daily log");
            Console.WriteLine("3.  Read daily saves states");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1": //Creating a backup
                    Console.WriteLine("Choose the type of backup you wanna do:");
                    Console.WriteLine("1. Differential");
                    Console.WriteLine("2. Complete");
                    string path = Console.ReadLine();
                    DirectoryInfo mydir = new DirectoryInfo(@path);

                    // getting the files in the directory, their names and size
                    FileInfo[] f = mydir.GetFiles();
                    //Directory after that
                    DirectoryInfo[] diArr = mydir.GetDirectories();

                    foreach (FileInfo file in f)
                    {
                        Console.WriteLine("File Name: {0} Size: {1}", file.Name, file.Length);
                    }
                    // Display the names of the directories.
                    foreach (DirectoryInfo dri in diArr)
                        Console.WriteLine(dri.Name);
                    Console.ReadKey(); //awaiting input to leave
                    break;
                case "2": //Daily log to print
                    SearchFile.Read();
                    break;
                case "3": // Daily save state to print
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice.");
                    break;
            }
        }
    }
}