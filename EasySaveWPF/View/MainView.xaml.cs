using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace EasySaveWPF.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //bouton chemin copie
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                CopyFilePath.Text = dialog.FileName; //Affichage dans la fenètre principale
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //bouton  chemin coller
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DestinationFilePath.Text = dialog.FileName; //Affichage dans la fenètre principale
            }
        }
    }
}
