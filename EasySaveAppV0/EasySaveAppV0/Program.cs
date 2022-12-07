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
            Console.WriteLine("Easysave - Choose a Language :\r\n 1. English \r\n 2. frensh ");

            string ChoiceLanguage = Console.ReadLine();
            if (ChoiceLanguage == "1")
            { 
            Console.WriteLine("Easysave - make your choice \r\n 1.  Create a save  \r\n 2.  Read the daily log  \r\n 3.  Read daily saves states");
            }
            else if (ChoiceLanguage == "2")
            {
               Console.WriteLine("Easysave - faites votre choix\r\n 1.Créer une sauvegarde \r\n 2.Ouvrir les Logs \r\n 3.Ouvrir les States");
            }
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1": //Creating a backup
                    if (ChoiceLanguage == "1")
                    {
                        Console.WriteLine("Name of the folder");
                    }
                    else if (ChoiceLanguage == "2")
                    {
                        Console.WriteLine("Nom du dossier");
                    }
                    string directoryName = Console.ReadLine();
                    if (ChoiceLanguage == "1")
                    {
                        Console.WriteLine("Path that you want to copy (drop the file/folder)");
                    }
                    else if (ChoiceLanguage == "2")
                    {
                        Console.WriteLine("Chemin que vous souhaitez copier (déposez le fichier/dossier)");
                    }
                    string copyPath = Console.ReadLine(); //String for the copied path
                    if (ChoiceLanguage == "1")
                    {
                        Console.WriteLine("Path where to paste the copy (drop the file/folder)");
                    }
                    else if (ChoiceLanguage == "2")
                    {
                        Console.WriteLine("Chemin où coller la copie (déposer le fichier/dossier)");
                    }
                    string pathPaste = Console.ReadLine(); //String for the pasted path
                    if (ChoiceLanguage == "1")
                    {
                        Console.WriteLine("Choose the type of backup you wanna do:\r\n 1. Differential \r\n 2. Complete");
                    }
                    else if (ChoiceLanguage == "2")
                    {
                        Console.WriteLine("Choisissez le type de sauvegarde que vous voulez faire:\r\n 1. Différentiel \r\n 2. Complète");
                    }
                    string saveChoice = Console.ReadLine();
                    int sizeofFiles = Directory.GetFiles(copyPath).Length;
                    ObjfileEditing.Variables(directoryName, copyPath, pathPaste, sizeofFiles);
                    if (saveChoice=="1")
                    {
                        ObjfileEditing.DiffSave();
                        if (ChoiceLanguage == "1")
                        {
                            Console.WriteLine("Differential save completed ");
                        }
                        else if (ChoiceLanguage == "2")
                        {
                            Console.WriteLine("Sauvegarde différentiel terminé");
                        }
                    }
                    else if(saveChoice=="2")
                    {
                        ObjfileEditing.CompleteSave();
                        if (ChoiceLanguage == "1")
                        {
                            Console.WriteLine("Complete save completed");
                        }
                        else if (ChoiceLanguage == "2")
                        {
                            Console.WriteLine("Sauvegarde complète terminé");
                        }
                    }
                    else
                    {
                        if (ChoiceLanguage == "1")
                        {
                            Console.WriteLine("Error. Please enter a valid choice");
                        }
                        else if (ChoiceLanguage == "2")
                        {
                            Console.WriteLine("Erreur. Veuillez entrer un choix valide");
                        }
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
                    if (ChoiceLanguage == "1")
                    {
                        Console.WriteLine("EError. Please enter a valid choice");
                    }
                    else if (ChoiceLanguage == "2")
                    {
                        Console.WriteLine("Erreur. Veuillez entrer un choix valide");
                    }
                    Program.Choice();
                    break;
            }
        }
    }
}
