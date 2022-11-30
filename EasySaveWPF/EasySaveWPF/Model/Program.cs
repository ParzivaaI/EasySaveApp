using System;
using System.IO;

namespace EasySaveWPF.Model
{
    class Program
    {
        /*static void Main(string[] args)
        {
          //  Console.WriteLine("EasySave.v1 - Make your language choice");
            //LanguagechoiceFunction
            Choice();
        }*/
        public static void Choice()
        {
            FileEditing ObjfileEditing = new FileEditing();
            Console.WriteLine("Easysave - make your choice / Faites votre choix\r\n 1.  Create a save / Faire une sauvegarde \r\n 2.  Read the daily log / Voir les logs journaliers \r\n 3.  Read daily saves states / Voir l'état des sauvegardes");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1": //Creating a backup
                    Console.WriteLine("Name of the folder/Nom du dossier");
                    string directoryName = Console.ReadLine();
                    Console.WriteLine("Path that you want to copy (drop the file/folder) / Chemin que vous souhaitez copier (déposez le fichier/dossier)");
                    string copyPath = Console.ReadLine(); //String for the copied path
                    Console.WriteLine("Path where to paste the copy (drop the file/folder) / Chemin où coller la copie (déposer le fichier/dossier)");
                    string pathPaste = Console.ReadLine(); //String for the pasted path
                    Console.WriteLine("Choose the type of backup you wanna do / Choisissez le type de sauvegarde que vous voulez faire:\r\n 1. Differential / Différentiel \r\n 2. Complete / Complète") ;
                    string saveChoice = Console.ReadLine();
                    int sizeofFiles = Directory.GetFiles(copyPath).Length;
                    ObjfileEditing.Variables(directoryName, copyPath, pathPaste, sizeofFiles);
                    if (saveChoice=="1")
                    {
                        ObjfileEditing.DiffSave();
                        Console.WriteLine("Differential save completed / Sauvegarde différentiel terminé.");
                    }
                    else if(saveChoice=="2")
                    {
                        ObjfileEditing.CompleteSave();
                        Console.WriteLine("Complete save completed Sauvegarde complète terminé.");
                    }
                    else
                    {
                        Console.WriteLine("Error. Please enter a valid choice / Erreur. Veuillez entrer un choix valide.");
                    }
                    Console.ReadKey(); //awaiting input to leave
                    break;
                case "2": //Daily log to print
                    Console.WriteLine(File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+@"\"+DateTime.Now.ToString("dd-MM-yyyy")+".json"));
                    break;
                case "3": // Daily save state to print
                    Console.WriteLine(File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\" + DateTime.Now.ToString("dd-MM-yyyy") + " State.json"));
                    break;
                default:
                    Console.WriteLine("Error. Please enter a valid choice / Erreur. Veuillez entrer un choix valide.\n");
                    Program.Choice();
                    break;
            }
        }
    }
}
