using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveWPF.Core;
using EasySaveWPF.ViewModel;
using EasySaveWPF.View;

namespace EasySaveWPF.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ViewModel MainVM { get; set; }
        public RelayCommand SaveButton { get; set; }
        private object _currentView;
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
            SaveButton = new RelayCommand(obj => { System.Windows.Application.Current.Shutdown();});
            CurrentView = MainVM;
        }

    }
}