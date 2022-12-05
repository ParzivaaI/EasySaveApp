using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveWPF.Core;
using EasySaveWPF.ViewModel;
using EasySaveWPF.View;
using EasySaveWPF.Model;

namespace EasySaveWPF.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand FrenshCommand { get; set; }
        public RelayCommand EnglishCommand { get; set; }
        public ViewModel MainVM { get; set; }

        private object _currentView;
        public object CurrentView

           {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public English Content;
        public MainViewModel()
        {
            MainVM = new ViewModel();
            CurrentView = MainVM;

            Content = new English();
           
            FrenshCommand = new RelayCommand(o =>
            {
              

            });


            EnglishCommand = new RelayCommand(o =>
            {


            });
        }
        public string Complete
        {
            get { return Content.Complete; }
            set
            {
                Content.Complete = value;
                OnPropertyChanged("Complete");
            }

        }
    }
}
