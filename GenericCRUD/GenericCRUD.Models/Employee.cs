using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GenericCRUD.Models
{
    [Serializable]
    class Employee : INotifyPropertyChanged
    {
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _birthDate;
        private string _role;
        
        public Employee()
        {
        }

        public Employee(string name, string email, string phoneNumber, string birthDate, string role)
        {
            this._name = name;
            this._email = email;
            this._phoneNumber = phoneNumber;
            this._birthDate = birthDate;
            this._role = role;
        }

        public string Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
