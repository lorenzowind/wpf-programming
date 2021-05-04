using Microsoft.Win32;

namespace GenericCRUD.ViewModels
{
    public interface IDialogService
    {
        #region Methods
        SaveFileDialog SaveFileDialog(string filter, string initialDirectory);
        OpenFileDialog OpenFileDialog(string initialDirectory);
        void OpenInfoWindow(string caption, string text);
        #endregion
    }
}
