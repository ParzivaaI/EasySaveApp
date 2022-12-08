using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using EasySaveWPF.Core;
using EasySaveWPF.Model;

namespace EasySaveWPF.ViewModel
{
    internal class SaveViewModel : INotifyPropertyChanged
    {
        private Save _save; //Creer un objet sauvegarde

        public SaveViewModel() { _save = new Save(); } //Creer l'objet viewmodel de sauvegarde
        public string FileName //Champ pour récupérer le nom du fichier
        {
            get { return _save.Name; }
            set
            {
                _save.Name = value;
                OnPropertyChanged("FileName");
            }
        }
        public string SaveType
        {
            get { return _save.SaveCompleted; }
            set
            {
                string[] name = value.Split(':');
                string[] type = name[1].Split(' ');
                _save.SaveCompleted = type[1];
                OnPropertyChanged("SaveType");
            }
        }

        public string FileSource
        {
            get { return _save.CopyDirectory; }
            set
            {
                _save.CopyDirectory = value;
                OnPropertyChanged("FileSource");
            }

        }
        public string FileDestination
        {
            get { return _save.PasteDirectory; }
            set
            {
                _save.PasteDirectory = value;
                OnPropertyChanged("FileDestination");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
