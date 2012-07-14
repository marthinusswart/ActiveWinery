using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveWinery.Services;
using ActiveWinery.Views;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Modules
{
    public class ShellModule : IModule
    {
        #region Fields

        private IUnityContainer _container;
        private IRegionManager _regionManager;

        #endregion

        #region Constructors

        public ShellModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        #endregion

        #region Methods

        public void Initialize()
        {
            _container.RegisterInstance<IWindowsManager>(_container.Resolve<WindowsManager>());
            _container.RegisterInstance<IBinder>(_container.Resolve<Binder>());
            _container.RegisterInstance<IViewModelLocator>(_container.Resolve<ViewModelLocator>());

            var toolbar = _container.Resolve<ToolbarView>();
            _regionManager.Regions["ToolbarRegion"].Add(toolbar);
            _regionManager.Regions["ToolbarRegion"].Activate(toolbar);
        }

        #endregion
    }
}
