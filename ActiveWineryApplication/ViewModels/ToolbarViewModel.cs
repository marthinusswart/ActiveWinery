using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ActiveWinery.Administration.Views;
using ActiveWinery.Configuration.Views;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using NeoOrange.Controls;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.ViewModels
{
    public class ToolbarViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public IWindowsManager WindowsManager { get; set; }

        #endregion

        #region Constructors

        public ToolbarViewModel(IWindowsManager windowsManager)
        {
            PropertyChanged += (s, e) => { };
            WindowsManager = windowsManager;
        }

        #endregion

        #region Methods

        public void OpenConfig()
        {
            WindowsManager.OpenWindow<ConfigurationView>("MainRegion", "ConfigWindow", true);
        }

        #endregion
    }
}
