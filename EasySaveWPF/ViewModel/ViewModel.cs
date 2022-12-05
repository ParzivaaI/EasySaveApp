using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EasySaveWPF.ViewModel
{
    class ViewModel
    {
        public ICommand ButtonCommand { get; set; }

        public ViewModel()
        {
            ButtonCommand = new RelayCommand(o => MainButtonClick("MainButton"));
        }

        private void MainButtonClick(object sender)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
