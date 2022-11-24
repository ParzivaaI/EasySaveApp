using System;
using System.IO;

using EasySaveAppV0.Search;

namespace EasySaveAppV0
{
    class Program
    {
        static void Main(string[] args)
        {
          //  Console.WriteLine("EasySave.v1 - Make your language choice");
            //LanguagechoiceFunction
            Choice();
        }
        public static void Choice()
        {
            FileEditing ObjfileEditing = new FileEditing();
            Console.WriteLine("Easysave - make your choice / Faites votre choix\r\n 1.  Create a save / Faire une sauvegarde \r\n 2.  Read the daily log / Voir les logs journaliers \r\n 3.  Read daily saves states / Voir l'état des sauvegardes");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1": //Creating a backup
                    Console.WriteLine("Path that you want to copy (drop the file/folder) / Chemin que vous souhaitez copier (déposez le fichier/dossier)");
                    string copypath = Console.ReadLine(); //String for the copied path
                    Console.WriteLine("Path where to paste the copy (drop the file/folder) / Chemin où coller la copie (déposer le fichier/dossier)");
                    string pathpaste = Console.ReadLine(); //String for the pasted path
                    Console.WriteLine("Choose the type of backup you wanna do / Choisissez le type de sauvegarde que vous voulez faire:\r\n 1. Differential / Différentiel \r\n 2. Complete / Complète") ;
                    string savechoice = Console.ReadLine();
                    if (savechoice=="1")
                    {
                        ObjfileEditing.DiffSave(copypath, pathpaste);
                        Console.WriteLine("Differential save completed / Sauvegarde différentiel terminé.");
                    }
                    else if(savechoice=="2")
                    {
                        ObjfileEditing.CompleteSave(copypath, pathpaste);
                        Console.WriteLine("Complete save completed Sauvegarde complète terminé.");
                    }
                    else
                    {
                        Console.WriteLine("Error. Please enter a valid choice / Erreur. Veuillez entrer un choix valide.");
                    }
                    Console.ReadKey(); //awaiting input to leave
                    break;
                case "2": //Daily log to print
                    //SearchFile.Read();
                    break;
                case "3": // Daily save state to print
                    break;
                default:
                    Console.WriteLine("Error. Please enter a valid choice / Erreur. Veuillez entrer un choix valide.\n");
                    Program.Choice();

                    break;
            }
        }
    }
}