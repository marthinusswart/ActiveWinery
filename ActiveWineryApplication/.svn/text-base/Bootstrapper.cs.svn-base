using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ActiveWinery.Administration.Modules;
using ActiveWinery.Configuration.Modules;
using ActiveWinery.Modules;
using Microsoft.Practices.Composite.UnityExtensions;

namespace ActiveWinery
{
    public class Bootstrapper : UnityBootstrapper 
    {
        #region Methods

        protected override DependencyObject CreateShell()
        {
            var shell = new Shell();
            shell.Show();
            return shell;
        }

        protected override void InitializeModules()
        {
            var module = Container.Resolve<ShellModule>();
            module.Initialize();

            var configurationModule = Container.Resolve<ConfigurationModule>();
            configurationModule.Initialize();

            var administrationModule = Container.Resolve<AdministrationModule>();
            administrationModule.Initialize();
        }

        #endregion
    }
}
