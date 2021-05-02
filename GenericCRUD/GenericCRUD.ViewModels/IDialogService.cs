namespace GenericCRUD.ViewModels
{
    public interface IDialogService
    {
        DialogResult SaveFileDialog();
        DialogResult OpenFileDialog();
        void OpenInfoWindow(string caption, string text);
    }
}
