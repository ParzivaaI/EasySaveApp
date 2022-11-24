using System;
using System.IO;

namespace EasySaveAppV0.Search
{ 
    public class FileEditing
    {   
        string name;
        string copyDirectory;
        string pasteDirectory;

        public void Variables(string name, string copyDirectory,string pasteDirectory)
        {
            this.name = name;
            this.copyDirectory = copyDirectory;
            this.pasteDirectory = pasteDirectory;
        }

        public void CompleteSave()
        {
            pasteDirectory += @"\" + name;
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory)); //créer le dossier dans la nouvelle sauvegarde pour chaque dossier existant

            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
        }
        public void DiffSave()
        {
            pasteDirectory += @"\" + name;
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*",
                SearchOption.AllDirectories))
                if(Directory.GetLastAccessTime(dirPath)>Directory.GetLastAccessTime(copyDirectory))
                { 
                    Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory));
                }
            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*",
                SearchOption.AllDirectories))
                if (File.GetLastAccessTime(newPath) > File.GetLastAccessTime(newPath.Replace(copyDirectory, pasteDirectory)))
                { 
                    File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                }
        }
    }
}