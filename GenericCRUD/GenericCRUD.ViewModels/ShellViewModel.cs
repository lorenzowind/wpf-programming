using Caliburn.Micro;

namespace GenericCRUD.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        #region Properties
        private object _currentViewModel;

        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            private set
            {
                _currentViewModel = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        #region Constructors
        public ShellViewModel()
        {
            CurrentViewModel = IoC.Get<MainViewModel>();
        }
        #endregion

        #region Helpers
        protected override void OnInitialize()
        {
            ActivateItem(CurrentViewModel);
        }
        #endregion
    }
}
