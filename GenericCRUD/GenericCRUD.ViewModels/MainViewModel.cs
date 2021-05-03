using Caliburn.Micro;
using System;

namespace GenericCRUD.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IDialogService _dialogService;
        private readonly IWindowManager _windowManager;
        
        public MainViewModel()
        {
        }

        public MainViewModel(IDialogService dialogService, IWindowManager windowManager)
        {
            _dialogService = dialogService;
            _windowManager = windowManager;
        }

        #region MenuMethods
        public void MiNewFile()
        {
        }

        public void MiOpenFile()
        {
        }

        public void MiSaveFile()
        {
        }

        public void MiSaveFileAs()
        {
        }

        public void MiExit()
        {
            Environment.Exit(0);
        }

        public void MiAbout()
        {
        }
        #endregion

        #region EmployeeMethods
        public void BtnSearchEmployee()
        {
        }

        public void BtnAddEmployee()
        {
        }

        public void BtnEditEmployee()
        {
        }

        public void BtnRemoveEmployee()
        {
        }
        #endregion
    }
}
