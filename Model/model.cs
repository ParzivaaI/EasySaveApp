using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveWPF.View;
using EasySaveWPF.ViewModel;

namespace EasySaveWPF.Models
{


    internal class Model
    {
        public string FileName { get; set; }
        public Model() 
        {
            FileName = "Enter text";
        }

        public Model(string fileName)
        {
            FileName= fileName;
        }
        public string ChoiceFile()
        {
            return FileName;
        }

    }
}
