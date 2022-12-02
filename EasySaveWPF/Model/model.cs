using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveWPF.View;
using Newtonsoft.Json;
using System.Windows.Data;

namespace EasySaveWPF.Model
{
    class Model
    {
        public static void RunApp(string[] args)
        {
            //  Console.WriteLine("EasySave.v1 - Make your language choice");
            //LanguagechoiceFunction
            Choice();
        }
        public static void Choice()
        {
            FileEditing ObjfileEditing = new FileEditing();
            string directoryName = ""; //besoin du path de la view
            string copyPath = Console.ReadLine(); //String for the copied path
                    Console.WriteLine("Path where to paste the copy (drop the file/folder) / Chemin où coller la copie (déposer le fichier/dossier)");
                    string pathPaste = Console.ReadLine(); //String for the pasted path
                    Console.WriteLine("Choose the type of backup you wanna do / Choisissez le type de sauvegarde que vous voulez faire:\r\n 1. Differential / Différentiel \r\n 2. Complete / Complète");
                    string saveChoice = Console.ReadLine();
                    int sizeofFiles = Directory.GetFiles(copyPath).Length;
                    ObjfileEditing.Variables(directoryName, copyPath, pathPaste, sizeofFiles);
                    if (saveChoice == "1")
                    {
                        ObjfileEditing.DiffSave();
                        Console.WriteLine("Differential save completed / Sauvegarde différentiel terminé.");
                    }
                    else if (saveChoice == "2")
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
                    Console.WriteLine(File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\" + DateTime.Now.ToString("dd-MM-yyyy") + ".json"));
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
        public static string[] GetBlackList()//Fonction pour obtenir la liste noire des programmes
        {
            using (StreamReader blacklistreader = new StreamReader(@"..\..\..\Ressources\BusinessSoftwareBlacklist.json"))
            {
                BlackList[] theblacklist;
                string[] blacklist_array;
                string tojson = blacklistreader.ReadToEnd();
                List<BlackList> items = JsonConvert.DeserializeObject<List<BlackList>>(tojson);
                theblacklist = items.ToArray();
                blacklist_array = theblacklist[0].Black_list.Split(',');
                return blacklist_array;//retour des noms des programmes dans la blacklist
            }
        }
    }
}
