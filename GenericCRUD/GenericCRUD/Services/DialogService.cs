using System.Windows;
using Microsoft.Win32;
using GenericCRUD.ViewModels;

namespace GenericCRUD.Views
{
    public class DialogService : IDialogService
    {
        #region Methods
        public SaveFileDialog SaveFileDialog(string filter, string initialDirectory)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                InitialDirectory = initialDirectory
            };

            return saveFileDialog.ShowDialog() == true ? saveFileDialog : null;
        }

        public OpenFileDialog OpenFileDialog(string initialDirectory)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = initialDirectory
            };

            return openFileDialog.ShowDialog() == true ? openFileDialog : null;
        }

        public void OpenInfoWindow(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
    }
}
