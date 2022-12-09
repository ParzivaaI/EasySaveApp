using EasySaveWPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Media.Animation;

namespace EasySaveWPF.ViewModel
{
    class ViewModel : Core.ObservableObject
    {
        Model.FileEditing typeSave = new Model.FileEditing();
        Model.InterfaceView interaction = new Model.InterfaceView();
       
        public ViewModel() { }

        private RelayCommand _completeSave;
        public RelayCommand _browseSourcePathButton;
        public RelayCommand _browseDestinationPathButton;
        public RelayCommand _languageFR;
        public RelayCommand _languageEN;
        public RelayCommand _saveButton;
        public ObservableObject _pathSource;

        public RelayCommand CompleteSaveCommand
        {
            get
            {
                return _completeSave ?? new RelayCommand(o => { typeSave.CompleteSave(); });
            }
        }

        public RelayCommand BrowseSourcePathButton
        {
            get
            {
                return _browseSourcePathButton ?? new RelayCommand(o => { interaction.ButtonBrowseSource(); });
            }
        }

        public RelayCommand BrowseDestinationPathButton
        {
            get
            {
                return _browseDestinationPathButton ?? new RelayCommand(o => { interaction.ButtonBrowseTarget(); });
            }
        }

        public RelayCommand LanguageFR
        {
            get
            {
                return _languageFR ?? new RelayCommand(o => { });
            }
        }

        public RelayCommand LanguageEN
        {
            get
            {
                return _languageEN ?? new RelayCommand(o => { });
            }
        }

        public RelayCommand SaveButton
        {
            get
            {
                return _saveButton ?? new RelayCommand(o => { });
            }

        }
        public ObservableObject PathSource
        {
            get
            {
                return _pathSource ?? new ObservableObject();
            }
            set 
            {
                _pathSource = value;
                OnPropertyChanged(@"C:\");
            }
        }
    }
}
