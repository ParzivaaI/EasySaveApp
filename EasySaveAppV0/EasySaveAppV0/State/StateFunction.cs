using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Timers;

using EasySaveAppV0.Search;
    
    
 
   namespace EasySaveAppV0.state

{
    public class StateFunction 
{ 
        public string CurrentDirectory
        {
            get;
            set;
        }

    public String FileName
    {
            //File Name
            get;
            set;
    }
    
    public string FilePath
        {
            get;
            set;
        }

        public int FileLength
        {
            get;
            set;
        }

        public StateFunction()
        {
            //Ajoute les informations à la création du fichier json de départ
            this.CurrentDirectory = @"C:\EasySave\State";
            this.FileName = DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
            this.FileLength = 0;
        }

        public void StateCreate(string adresscopy, string adresspast, string FName,bool isActive, int filesLeft, long totalFileSize)
        {
                this.FileLength = filesLeft;
                using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
                {
                    w.Write("Name : {0} \n", FName);
                    w.Write("FileSource : {0} \n", adresscopy);
                    w.Write("FileTarget : {0} \n", adresspast);
                    w.Write("Time : {0} {1} \n", DateTime.Now.ToShortDateString(),DateTime.Now.ToLongTimeString());
                    w.Write("FilesLeft : {0} \n", FileLength);
                    w.Write("Active: {0}\n",isActive);
                    w.Write("Size: {0}\n", totalFileSize);
                    w.Write("\n");
                }
        }
    }
}