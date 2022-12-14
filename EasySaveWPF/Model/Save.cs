using Newtonsoft.Json;
using System;
using System.IO;
using System.Timers;
using System.Text;

namespace EasySaveWPF.Model
{
    public class Save
    {
        string name;
        string copyDirectory;
        string pasteDirectory;
        int leftToTransfer;
        string saveCompleted;
        public static int TimeCounter = 0;
        public static Timer timer = new Timer(500);

        public int LeftToTransfer { get => leftToTransfer; set => leftToTransfer = value; }
        public string PasteDirectory { get => pasteDirectory; set => pasteDirectory = value; }
        public string Name { get => name; set => name = value; }
        public string CopyDirectory { get => copyDirectory; set => copyDirectory = value; }
        public string SaveCompleted { get => SaveCompleted; set => SaveCompleted = value; }

        /*string[] blacklistedApps = Model.GetBlackList();*/

        public Save()
        {
            Name = "EasySaved";
            CopyDirectory = @"C:\";
            PasteDirectory = @"C:\Program Files";
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
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*", SearchOption.AllDirectories))
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
                FName = name,
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
            SaveCompleted = "Differential";
            long totalFileSize = 0;
            //Demarrer le timer
            timer.Elapsed += SaveTimer;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            TimeCounter++;
            pasteDirectory += @"\" + name;
            //Ajout du nom au path pour créer le dossier de sauvegarde
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
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
                    {
                        stateIsActive = true;
                    }
                    else
                    {
                        stateIsActive = false;
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

/*        public static bool IsBlacklisted(string[] blacklist)
        {
            foreach (string processlist in blacklist)
            {
                if (Process.GetProcessesByName(processlist).Length > 0)
                {
                    return true;
                }
            }
            return false;
        }*/
        void SaveTimer(object sender, ElapsedEventArgs e)
        {
            TimeCounter++;
        }
        public string EncryptDecrypt(string szPlainText, int clehash)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ clehash);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }
/*        public void Encrypt(string sourceDir, string targetDir)//Fonction de cryptage
        {
            using (Process process = new Process())//Création du process
            {
                process.StartInfo.FileName = @"..\..\..\Ressources\CryptoSoft\CryptoSoft.exe"; //Calls the process that is CryptoSoft
                process.StartInfo.Arguments = String.Format("\"{0}\"", sourceDir) + " " + String.Format("\"{0}\"", targetDir); //Preparation of variables for the process.
                process.Start(); //Launching the process
                process.Close();

            }

        }*/
    }
}
