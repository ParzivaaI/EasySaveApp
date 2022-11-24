using System;
using System.IO;

using EasySaveAppV0.Search;
using EasySaveAppV0.language;

namespace EasySaveAppV0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EasySave.v1 - Make your language choice");
            //LanguagechoiceFunction
            Choice();
        }
        public static void Choice()
        {
            FileEditing ObjfileEditing = new FileEditing();
            Console.WriteLine("Easysave - make your choice\r\n 1.  Create a save \r\n 2.  Read the daily log \r\n 3.  Read daily saves states");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1": //Creating a backup
                    Console.WriteLine("Name of the save:");
                    string directoryName = Console.ReadLine(); //String for the copied path
                    Console.WriteLine("Path that you want to copy (drop the file/folder)");
                    string copyPath = Console.ReadLine(); //String for the copied path
                    Console.WriteLine("Path where to paste the copy (drop the file/folder)");
                    string pathPaste = Console.ReadLine(); //String for the pasted path
                    Console.WriteLine("Choose the type of backup you wanna do:\r\n 1. Differential \r\n 2. Complete") ;
                    string savechoice = Console.ReadLine();
                    ObjfileEditing.Variables(directoryName, copyPath, pathPaste);
                    if (savechoice=="1")
                    {
                        ObjfileEditing.DiffSave();
                        Console.WriteLine("Differential save completed.");
                    }
                    else if(savechoice=="2")
                    {
                        ObjfileEditing.CompleteSave();
                        Console.WriteLine("Complete Save completed.");
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