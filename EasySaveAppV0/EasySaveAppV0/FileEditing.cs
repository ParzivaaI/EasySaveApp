using System;
using System.IO;

namespace EasySaveAppV0.Search
{ 
    public class FileEditing
    {
        public void CompleteSave(string Name,string sDir, string sDirPaste)
        {
            sDirPaste += @"\" + Name;
            foreach (string dirPath in Directory.GetDirectories(sDir, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sDir, sDirPaste)); //créer le dossier dans la nouvelle sauvegarde pour chaque dossier existant

            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(sDir, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sDir, sDirPaste), true);
        }
        public void DiffSave(string name, string sDir, string sDirPaste)
        {
            sDirPaste += @"\" + name;

            //Creating the directories
            foreach (string dirPath in Directory.GetDirectories(sDir, "*",
                SearchOption.AllDirectories))
                if(Directory.GetLastAccessTime(dirPath)>Directory.GetLastAccessTime(sDir))
                { 
                    Directory.CreateDirectory(dirPath.Replace(sDir, sDirPaste));
                }
            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(sDir, "*.*",
                SearchOption.AllDirectories))
                if (File.GetLastAccessTime(newPath) > File.GetLastAccessTime(newPath.Replace(sDir, sDirPaste)))
                { 
                    File.Copy(newPath, newPath.Replace(sDir, sDirPaste), true);
                }
        }
    }
}