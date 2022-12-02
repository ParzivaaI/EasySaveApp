using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveWPF.Core;
using EasySaveWPF.ViewModel;
using EasySaveWPF.View;
using EasySaveWPF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasySaveWPF.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ViewModel MainVM { get; set; }

        private Object _currentView;
        public object CurrentView
            
           {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            MainVM = new ViewModel();
            CurrentView = MainVM;
            _model = new Model();
        }
        private Model _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Model
        {
            get { return _model.ChoiceFile(); }
            set
            {
                _model = new Model(value);
                OnPropertyChanged("Enter text");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string path = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(path));
        }

        private RelayCommands _pathsource;

        public RelayCommands Pathsource
        { get 
            {
                 //return _updateHelloToUpperCommand ?? (_updateHelloToUpperCommand = new RelayCommands());

                return _pathsource; 
            }
        } 

    }
}
