using System;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EasySaveWPF.Model
{ 
    public class FileEditing
    {   
        string name;
        string copyDirectory;
        string pasteDirectory;
        int leftToTransfer;
        private Model model;
/*        string[] blacklistedApps = Model.GetBlackList();*/


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
                totalFileSize = newPath.Length;
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
            var date = DateTime.Now;
            var logger = new Logger
            {
                FName = name ,
                FileSource = copyDirectory,
                FileTarget = pasteDirectory,
                FileSize = totalFileSize,
                Time = date
            };
            string jsonString = JsonConvert.SerializeObject(logger);
            logger.SaveLog(jsonString);

        }
        public void DiffSave()
        {
            long totalFileSize = 0;
            pasteDirectory += @"\" + name;
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*", SearchOption.AllDirectories))
                    if (Directory.GetLastAccessTime(dirPath) > Directory.GetLastAccessTime(copyDirectory))
                    {
                        Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory));
                    }
                //Copie les fichiers, remplace si nom identique
                foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
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
                var date = DateTime.Now;
                var logger = new Logger
                {
                    FName = name,
                    FileSource = copyDirectory,
                    FileTarget = pasteDirectory,
                    FileSize = totalFileSize,
                    Time = date
                };
                string jsonString = JsonConvert.SerializeObject(logger);
                logger.SaveLog(jsonString);
        }

        public static bool IsBlacklisted(string[] blacklist)
        {
            foreach (string processlist in blacklist)
            {
                if (Process.GetProcessesByName(processlist).Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}