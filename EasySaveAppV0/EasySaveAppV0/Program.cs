using System;
using System.IO;

using EasySaveAppV0.Search;

namespace EasySaveAppV0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EasySave.v1 - Make your language choice");
            ChoiceLang();
            Choice();
        }
        public static void ChoiceLang()
        {
            Console.WriteLine("en : English");
            Console.WriteLine("fr :Français");
            string langChoice = Console.ReadLine();
            switch (langChoice)
            {
                case "en":
            }

        }
        public static void Choice()
        {
            FileEditing ObjfileEditing = new FileEditing();
            Console.WriteLine("Easysave - make your choice");
            Console.WriteLine("1.  Create a save");
            Console.WriteLine("2.  Read the daily log");
            Console.WriteLine("3.  Read daily saves states");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1": //Creating a backup
                    Console.WriteLine("Path that you want to copy (drop the file/folder)");
                    string copypath = Console.ReadLine();
                    Console.WriteLine("Path where to paste the copy (drop the file/folder)");
                    string pathpaste = Console.ReadLine();
                    Console.WriteLine("Choose the type of backup you wanna do:");
                    Console.WriteLine("1. Differential");
                    Console.WriteLine("2. Complete");
                    string savechoice = Console.ReadLine();
                    if (savechoice=="1")
                    {
                        ObjfileEditing.DirSearch(copypath, pathpaste);
                        Console.WriteLine("Save complete.");
                    }
                    else if(savechoice=="2")
                    {
                        ObjfileEditing.DirSearch(copypath, pathpaste);
                        Console.WriteLine("Save complete.");
                    }
                    else
                    {
                        Console.WriteLine("Error. Please enter a valid choice.");
                    }
                    Console.ReadKey(); //awaiting input to leave
                    break;
                case "2": //Daily log to print
                    //SearchFile.Read();
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