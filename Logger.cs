using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Timers;

using EasySaveAppV0.Search;
    
    
 
   namespace EasySaveAppV0.log

{
    public class Logger 
{
        private static System.Timers.Timer aTimer;
        
        int secondCount = 0;

        //define log 
        public string CurrentDirectory
        {
            get;
            set;
        }

    //...

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

    public Logger()
        {
            this.CurrentDirectory = @"C:\Users\33767\source\repos\EasySaveApp\EasySaveAppV0\EasySaveAppV0";
            this.FileName = DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }

        public void SaveLog(string adresscopy, string adresspast, string FName)
        {
           
            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {

                w.Write("Name : {0} \n", FName);
                w.Write("FileSource : {0} \n", adresscopy);
                w.Write("FileTarget : {0} \n", adresspast);
                w.Write("Time : {0} {1} \n", DateTime.Now.ToShortDateString(),DateTime.Now.ToLongTimeString());
                w.Write("FileSize : {0} \n", adresscopy.Length);
                w.Write("\n");

            }
        }
    }
}