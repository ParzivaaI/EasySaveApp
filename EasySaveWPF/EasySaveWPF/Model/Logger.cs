using System;
using System.IO;    
 
   namespace EasySaveWPF.Model

{
    public class Logger 
{

        public string FName { get; set; }
        public string FileSource { get; set; }
        public string FileTarget { get; set; }
        public long FileSize { get; set; }
        public DateTimeOffset Time { get; set; }

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
            // Create a JSON files in the project folder
            string workingDirectory = Environment.CurrentDirectory;
            this.CurrentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            this.FileName = DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }

public void SaveLog(string message)
        {
            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {
                w.Write("{0} \n", message);
            }
        }
}
}