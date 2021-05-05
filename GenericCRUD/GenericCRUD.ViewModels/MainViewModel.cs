using Caliburn.Micro;
using System;
using GenericCRUD.Models;
using System.Data;
using System.ComponentModel;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

namespace GenericCRUD.ViewModels
{
    public class MainViewModel : Screen
    {
        #region Properties
        private readonly IDialogService _dialogService;
        private readonly IWindowManager _windowManager;

        private DataRowView _currentSelectedRow;

        public bool BtnEditEmployeeIsEnabled => IsRowSelected();
        public bool BtnRemoveEmployeeIsEnabled => IsRowSelected();
        public string TbkSelectionWarning => IsRowSelected() ? "" : "* Select employee in the table";

        public DataRowView CurrentSelectedRow
        {
            get => _currentSelectedRow;
            set
            {
                _currentSelectedRow = value;
                OnPropertyChanged();

                OnPropertyChanged("BtnEditEmployeeIsEnabled");
                OnPropertyChanged("BtnRemoveEmployeeIsEnabled");
                OnPropertyChanged("TbkSelectionWarning");
            }
        }

        private readonly Persistence _employees = new Persistence();

        private DataTable _currentDataTable;

        public DataTable CurrentDataTable
        {
            get => _currentDataTable;
            set
            {
                _currentDataTable = value;
                OnPropertyChanged();
            }
        }

        override
        public event PropertyChangedEventHandler PropertyChanged;
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

            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("BirthDate", typeof(string));
            dataTable.Columns.Add("Role", typeof(string));

            foreach (Employee item in _employees.List)
            {
                dataTable.Rows.Add(item.Id, item.Name, item.Email, item.PhoneNumber, item.BirthDate, item.Role);
            }

            return dataTable;
        }

        private bool IsRowSelected()
        {
            return _currentSelectedRow != null;
        }

        private Employee GetSelectedEmployee()
        {
            return new Employee
            {
                Id = CurrentSelectedRow.Row.Field<string>("Id"),
                Name = CurrentSelectedRow.Row.Field<string>("Name"),
                Email = CurrentSelectedRow.Row.Field<string>("Email"),
                PhoneNumber = CurrentSelectedRow.Row.Field<string>("PhoneNumber"),
                BirthDate = CurrentSelectedRow.Row.Field<string>("BirthDate"),
                Role = CurrentSelectedRow.Row.Field<string>("Role"),
            };
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            if (_employees.Filename != null)
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
            _windowManager.ShowDialog(new SaveEmployeeViewModel(_employees, "Add", null));

            CurrentDataTable = GetDataTable();
        }

        public void BtnEditEmployee()
        {
            _windowManager.ShowDialog(new SaveEmployeeViewModel(_employees, "Save", GetSelectedEmployee()));

            CurrentDataTable = GetDataTable();
        }

        public void BtnRemoveEmployee()
        {
            _windowManager.ShowDialog(new RemoveEmployeeViewModel(_employees, GetSelectedEmployee()));

            CurrentDataTable = GetDataTable();
        }
        #endregion
    }
}
