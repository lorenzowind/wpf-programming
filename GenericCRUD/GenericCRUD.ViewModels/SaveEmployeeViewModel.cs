using Caliburn.Micro;

namespace GenericCRUD.ViewModels
{
    public class SaveEmployeeViewModel : Screen
    {
        public SaveEmployeeViewModel()
        {
        }

        #region SaveEmployeeMethods
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
