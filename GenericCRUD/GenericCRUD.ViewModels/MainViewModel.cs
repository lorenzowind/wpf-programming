using Caliburn.Micro;
using System;
using GenericCRUD.Models;
using System.Data;
using System.ComponentModel;

namespace GenericCRUD.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        private readonly IDialogService _dialogService;
        private readonly IWindowManager _windowManager;

        private readonly Persistence _employees = new Persistence();

        private DataTable _currentDataTable;

        public DataTable CurrentDataTable
        {
            get
            {
                return _currentDataTable;
            }
            set
            {
                _currentDataTable = value;
                NotifyPropertyChanged("CurrentDataTable");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
        }

        public MainViewModel(IDialogService dialogService, IWindowManager windowManager)
        {
            _dialogService = dialogService;
            _windowManager = windowManager;

            CurrentDataTable = GetDataTable();
        }
        #endregion

        #region Helpers
        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("BirthDate", typeof(string));
            dataTable.Columns.Add("Role", typeof(string));

            foreach (Employee item in _employees.List)
            {
                dataTable.Rows.Add(item.Name, item.Email, item.PhoneNumber, item.BirthDate, item.Role);
            }

            return dataTable;
        }
        #endregion

        #region MenuItemsHandlers
        public void MiNewFile()
        {
            _employees.ClearList();

            _employees.ClearFileName();

            CurrentDataTable = GetDataTable();
        }

        public async void MiOpenFile()
        {
            await _employees.LoadFile(_dialogService.OpenFileDialog(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));

            CurrentDataTable = GetDataTable();
        }

        public async void MiSaveFile()
        {
            if (_employees.Filename != "")
            {
                await _employees.SaveFile();
            } 
            else
            {
                MiSaveFileAs();
            }
        }

        public async void MiSaveFileAs()
        {
            await _employees.SaveFileAs(_dialogService.SaveFileDialog("Text file(*.json)|*.json", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));
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

        #region ViewHandlers
        public void BtnSearchEmployee()
        {
        }

        public void BtnAddEmployee()
        {
            _windowManager.ShowDialog(new SaveEmployeeViewModel());
        }

        public void BtnEditEmployee()
        {
            _windowManager.ShowDialog(new SaveEmployeeViewModel());
        }

        public void BtnRemoveEmployee()
        {
            _windowManager.ShowDialog(new RemoveEmployeeViewModel());
        }
        #endregion
    }
}
