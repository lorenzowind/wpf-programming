using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GenericCRUD.ViewModels;

namespace GenericCRUD.Views
{
    public class Bootstrapper : BootstrapperBase
    {
        private WindsorContainer _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] {
                typeof (MainViewModel).Assembly,
                typeof (MainView).Assembly,
            };
        }

        protected override void Configure()
        {
            _container = new WindsorContainer();
            _container.Register(
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton(),
                Component.For<IDialogService>()
                    .ImplementedBy<DialogService>()
                    .LifestyleSingleton(),
                Component.For<IWindowManager>()
                    .ImplementedBy<WindowManager>()
                    .LifestyleSingleton()
            );

            RegisterViewModels();
        }

        private void RegisterViewModels()
        {
            _container.Register(Classes.FromAssembly(typeof(MainViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrWhiteSpace(key)
                ? _container.Resolve(service)
                : _container.Resolve(key, service);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
