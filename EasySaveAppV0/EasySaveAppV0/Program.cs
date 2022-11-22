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
                    Console.WriteLine("en vrai met le path ici j'ai pas codé");
                    string path = Console.ReadLine();
                    Console.WriteLine("chemin où faire la copie");  
                    string pathpaste = Console.ReadLine();
                    DirSearch(path,pathpaste);
                    static void DirSearch(string sDir,string sDirPaste)
                    {
                        try
                        {
                            foreach (string d in Directory.GetDirectories(sDir))
                            {
                                foreach (string f in Directory.GetFiles(d))
                                {
                                    //
                                    Console.WriteLine(f);
                                }
                            }
                        }
                        catch (System.Exception excpt)
                        {
                            Console.WriteLine(excpt.Message);
                        }
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