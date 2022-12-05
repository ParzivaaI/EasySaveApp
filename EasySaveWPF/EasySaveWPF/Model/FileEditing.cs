using Newtonsoft.Json;
using System;
using System.IO;
<<<<<<< Updated upstream:EasySaveWPF/EasySaveWPF/Model/FileEditing.cs
using Newtonsoft.Json;
=======
using System.Timers;
using System.Diagnostics;
>>>>>>> Stashed changes:EasySaveWPF/Model/FileEditing.cs

namespace EasySaveWPF.Model
{
    public class FileEditing
    {   
        string name;
        string copyDirectory;
        string pasteDirectory;
        int leftToTransfer;
<<<<<<< Updated upstream:EasySaveWPF/EasySaveWPF/Model/FileEditing.cs
=======
        string saveCompleted;
        public static int TimeCounter = 0;
        public static Timer timer = new Timer(500);

        public int LeftToTransfer { get => leftToTransfer; set => leftToTransfer = value; }
        public string PasteDirectory { get => pasteDirectory; set => pasteDirectory = value; }
        public string Name { get => name; set => name = value; }
        public string CopyDirectory { get => copyDirectory; set => copyDirectory = value; }
        public string SaveCompleted { get => SaveCompleted; set => SaveCompleted = value; }
>>>>>>> Stashed changes:EasySaveWPF/Model/FileEditing.cs

        /*string[] blacklistedApps = Model.GetBlackList();*/

        public FileEditing()
        {
            Name = "Save";
            CopyDirectory = @"C:\";
            PasteDirectory = @"E:\";
            SaveCompleted = "Complete";
        }
        public void Variables(string Name, string CopyDirectory, string PasteDirectory, int LeftToTransfer)
        {
            name = Name;
            copyDirectory = CopyDirectory;
            pasteDirectory = PasteDirectory;
            leftToTransfer = LeftToTransfer;
        }
        public void CompleteSave()
        {
            //Demarrer le timer
            timer.Elapsed += SaveTimer;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            TimeCounter++;
            var date = DateTime.Now; //Mettre date du jour
            long totalFileSize = 0; //Initialiser la taille totale du fichier
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
                LeftToTransfer--;
                TimeCounter++;
                totalFileSize = newPath.Length;
                if (LeftToTransfer >= 0)
                {
                    stateIsActive = true;
                }
                else
                {
                    stateIsActive = false;
                }
                ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, LeftToTransfer, totalFileSize, saveCompleted);
            }
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
            //Demarrer le timer
            timer.Elapsed += SaveTimer;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            TimeCounter++;
            pasteDirectory += @"\" + name;
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
<<<<<<< Updated upstream:EasySaveWPF/EasySaveWPF/Model/FileEditing.cs
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*",SearchOption.AllDirectories))
                if(Directory.GetLastAccessTime(dirPath)>Directory.GetLastAccessTime(copyDirectory))
                { 
                    Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory));
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
=======
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*", SearchOption.AllDirectories))
            { 
                if (Directory.GetLastAccessTime(dirPath) > Directory.GetLastAccessTime(copyDirectory))
                {
                    Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory));
                }
            }
            //Copie les fichiers, remplace si nom identique
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
            {
                if (File.GetLastAccessTime(newPath) > File.GetLastAccessTime(newPath.Replace(copyDirectory, pasteDirectory)))
                {
                bool stateIsActive;
                    File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                    LeftToTransfer--;
                    totalFileSize -= newPath.Length;
                    if (LeftToTransfer >= 0)
>>>>>>> Stashed changes:EasySaveWPF/Model/FileEditing.cs
                    {
                        stateIsActive = true;
                    }
                    else
                    {
                        stateIsActive = false;
<<<<<<< Updated upstream:EasySaveWPF/EasySaveWPF/Model/FileEditing.cs
                    }
                    ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, leftToTransfer, totalFileSize);
=======
                }
                    ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, LeftToTransfer, totalFileSize,saveCompleted);
                }
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
>>>>>>> Stashed changes:EasySaveWPF/Model/FileEditing.cs
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
<<<<<<< Updated upstream:EasySaveWPF/EasySaveWPF/Model/FileEditing.cs
=======
        void SaveTimer(object sender, ElapsedEventArgs e)
        {
            TimeCounter++;
        }

>>>>>>> Stashed changes:EasySaveWPF/Model/FileEditing.cs
    }
}