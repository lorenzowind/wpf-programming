using Caliburn.Micro;

namespace GenericCRUD.ViewModels
{
    public class SaveEmployeeViewModel : Screen
    {
        #region Constructors
        public SaveEmployeeViewModel()
        {
        }
        #endregion

        #region ViewHandlers
        public void BtnCancel()
        {
            TryClose();
        }

        public void BtnSaveEmployee()
        {
        }
        #endregion
    }
}
