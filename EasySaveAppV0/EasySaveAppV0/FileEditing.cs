using System;
using System.IO;


using EasySaveAppV0.log;
using EasySaveAppV0.state;

namespace EasySaveAppV0.Search
{ 
    public class FileEditing
    {   
        string name;
        string copyDirectory;
        string pasteDirectory;
        int leftToTransfer;

        public void Variables(string name, string copyDirectory, string pasteDirectory, int leftToTransfer)
        {
            this.name = name;
            this.copyDirectory = copyDirectory;
            this.pasteDirectory = pasteDirectory;
            this.leftToTransfer = leftToTransfer;
        }
        public void CompleteSave()
        {
            long totalFileSize = 0;
            pasteDirectory += @"\" + name;
            //créer la state
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*",SearchOption.AllDirectories))
            { 
                Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory)); //créer le dossier dans la nouvelle sauvegarde pour chaque dossier existant
            }
            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
            {
                totalFileSize += newPath.Length;
            }
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
            {
                bool stateIsActive;
                File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                leftToTransfer--;
                totalFileSize -= newPath.Length;
                if (leftToTransfer >= 0)
                {
                    stateIsActive = true;
                }
                else
                {
                    stateIsActive = false;
                }
                ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, leftToTransfer, totalFileSize);
            }
            Logger Logg = new Logger();
            Logg.SaveLog(copyDirectory, pasteDirectory, name);
        }
        public void DiffSave()
        {
            long totalFileSize = 0;
            pasteDirectory += @"\" + name;
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*",SearchOption.AllDirectories))
            {

                if (Directory.GetFileSystemEntries(pasteDirectory) == null)
                {
                    Console.WriteLine("Error, there is no files in this path / Erreur, il n'y pas de fichier dans ce dossier ");
                    DiffSave();
                }
                if (Directory.GetLastAccessTime(dirPath) > Directory.GetLastAccessTime(copyDirectory))
                {
                    Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory));
                }
            }
            //Copie les fichiers, remplace si nom identique
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*",SearchOption.AllDirectories))
                if (File.GetLastAccessTime(newPath) > File.GetLastAccessTime(newPath.Replace(copyDirectory, pasteDirectory)))
                {
                    bool stateIsActive;
                    File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                    leftToTransfer--;
                    totalFileSize -= newPath.Length;
                    if (leftToTransfer >= 0)
                    {
                        stateIsActive = true;
                    }
                    else
                    {
                        stateIsActive = false;
                    }
                    ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, leftToTransfer, totalFileSize);
                }
            Logger Logg = new Logger();
            Logg.SaveLog(copyDirectory, pasteDirectory, name);
        }
    }
}