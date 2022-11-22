using System;
using System.IO;

namespace EasySaveAppV0.Search
{ 
    public class FileEditing
    {
        public void DirSearch(string sDir, string sDirPaste)
        {
            //Creating the directories
            foreach (string dirPath in Directory.GetDirectories(sDir, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sDir, sDirPaste));

            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(sDir, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sDir, sDirPaste), true);
        }
    }
}