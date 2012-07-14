using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace ActiveWinery.Configuration.Modules
{
    public class ConfigurationModule : IModule
    {
        #region Fields

        private IUnityContainer _container;
        private IRegionManager _regionManager;

        #endregion

        #region Constructors

        public ConfigurationModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        #endregion

        #region Methods

        public void Initialize()
        {
        }

        #endregion
    }
}