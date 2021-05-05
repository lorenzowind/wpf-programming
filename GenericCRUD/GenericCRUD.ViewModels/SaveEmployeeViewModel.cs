using Caliburn.Micro;
using GenericCRUD.Models;
using System;

namespace GenericCRUD.ViewModels
{
    public class SaveEmployeeViewModel : Screen
    {
        #region Properties
        public Employee CurrentEmployee { get; }

        private readonly Persistence _employees;

        public bool BtnSaveEmployeeIsEnabled => !IsStatementEmpty();
        public string BtnSaveEmployeeContent { get; }
        #endregion

        #region Constructors
        public SaveEmployeeViewModel()
        {
        }

        public SaveEmployeeViewModel(Persistence employees, string btnSaveEmployeeContent, Employee employee)
        {
            _employees = employees;

            CurrentEmployee = employee ?? new Employee();
            BtnSaveEmployeeContent = btnSaveEmployeeContent;

            CurrentEmployee.PropertyChanged += (sender, args) => { UpdateButtonStates(); };
        }
        #endregion

        #region Helpers
        private void UpdateButtonStates()
        {
            NotifyOfPropertyChange(nameof(BtnSaveEmployeeIsEnabled));
        }

        private bool IsStatementEmpty()
        {
            return CurrentEmployee.Name == null ||
                CurrentEmployee.Email == null ||
                CurrentEmployee.PhoneNumber == null ||
                CurrentEmployee.BirthDate == null ||
                CurrentEmployee.Role == null;
        }
        #endregion

        #region ViewHandlers
        public void BtnCancel()
        {
            TryClose();
        }

        public void BtnSaveEmployee()
        {
            if (BtnSaveEmployeeContent == "Add")
            {
                _employees.Add(CurrentEmployee);
            } else
            {
                _employees.Save(CurrentEmployee);
            }

            TryClose();
        }
        #endregion
    }
}
