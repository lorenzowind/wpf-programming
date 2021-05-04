using Caliburn.Micro;

namespace GenericCRUD.ViewModels
{
    public class AboutViewModel : Screen
    {
        #region Constructors
        public AboutViewModel()
        {
        }
        #endregion

        #region ViewHandlers
        public void BtnClose()
        {
            TryClose();
        }
        #endregion
    }
}
