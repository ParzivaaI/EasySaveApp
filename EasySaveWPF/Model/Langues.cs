using EasySaveWPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveWPF.Model
{
    public class Langues
    {

        private string complete;
        private string differential;
        private string folderSource;
        private string folderTarget;
        private string save;
        private string browse;








    public string Complete { get => complete; set => complete = value; }
    public string Differential { get => differential; set => differential = value; }

    public string FolderSource { get => folderSource; set => folderSource = value; }

    public string FolderTarget { get => folderTarget; set => folderTarget = value; }

    public string Save { get => save; set => save = value; }

    public string Browse { get => browse; set => browse = value; }
    
    
    public Langues()
    {
            complete = Complete;
            differential = Differential;
            folderSource = FolderSource;
            folderTarget = FolderTarget;
            save = Save;
            browse = Browse;
    }
}
}
