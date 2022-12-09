using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using Microsoft.WindowsAPICodePack.Dialogs;

namespace EasySaveWPF.Model
{
    internal class InterfaceView
    {


        private string _pathTarget;
        private string _pathSource;

        public string PathTarget { get; set; }
        public string PathSource { get; set; }
        public void ButtonBrowseSource() //bouton chemin copie              object sender, RoutedEventArgs e
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
               PathSource = dialog.FileName; //Affichage dans la fenètre principale
            }
        }

        public void ButtonBrowseTarget() //bouton  chemin coller          object sender, RoutedEventArgs e
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                PathTarget = dialog.FileName; //Affichage dans la fenètre principale
            }
        }

        public void ButtonSave()
        {

        }
    }
}
