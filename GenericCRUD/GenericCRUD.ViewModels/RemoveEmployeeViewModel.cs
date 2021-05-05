using Caliburn.Micro;
using GenericCRUD.Models;

namespace GenericCRUD.ViewModels
{
    public class RemoveEmployeeViewModel : Screen
    {
        #region Properties
        private readonly Persistence _employees;
        public Employee CurrentEmployee { get; }
        #endregion

        #region Constructors
        public RemoveEmployeeViewModel()
        {
        }

        public RemoveEmployeeViewModel(Persistence employees, Employee employee)
        {
            _employees = employees;

            CurrentEmployee = employee;
        }
        #endregion

        #region ViewHandlers
        public void BtnCancel()
        {
            TryClose();
        }

        public void BtnRemoveEmployee()
        {
            _employees.Remove(CurrentEmployee);

            TryClose();
        }
        #endregion
    }
}
