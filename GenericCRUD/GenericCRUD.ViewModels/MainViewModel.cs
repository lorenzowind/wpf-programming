using Caliburn.Micro;
using System;
using GenericCRUD.Models;
using System.Data;
using Microsoft.Win32;

namespace GenericCRUD.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IDialogService _dialogService;
        private readonly IWindowManager _windowManager;

        private readonly Persistence _employees = new Persistence();

        public MainViewModel()
        {
        }

        public MainViewModel(IDialogService dialogService, IWindowManager windowManager)
        {
            _dialogService = dialogService;
            _windowManager = windowManager;

            CurrentDataTable = GetDataTable();
        }
        public DataTable CurrentDataTable { get; set; }

        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("BirthDate", typeof(string));
            dataTable.Columns.Add("Role", typeof(string));

            foreach (Employee item in _employees._list)
            {
                dataTable.Rows.Add(item.Name, item.Email, item.PhoneNumber, item.BirthDate, item.Role);
            }

            return dataTable;
        }

        #region MenuMethods
        public void MiNewFile()
        {
        }

        public async void MiOpenFile()
        {
            DialogResult dialog = _dialogService.OpenFileDialog();

            if (dialog.Result == true)
            {
                await _employees.LoadFile(dialog.FileName);
            }
        }

        public async void MiSaveFile()
        {
            if (_employees.SaveFileDialog != null)
            {
                await _employees.SaveFile();
            } 
            else
            {
                await _employees.SaveFileAs();
            }
        }

        public async void MiSaveFileAs()
        {
            await _employees.SaveFileAs();
        }

        public void MiExit()
        {
            Environment.Exit(0);
        }

        public void MiAbout()
        {
            _windowManager.ShowDialog(new AboutViewModel());
        }
        #endregion

        #region EmployeeMethods
        public void BtnSearchEmployee()
        {
        }

        public void BtnAddEmployee()
        {
            _windowManager.ShowDialog(new SaveEmployeeViewModel());
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
