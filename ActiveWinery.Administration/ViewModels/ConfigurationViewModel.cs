using System.ComponentModel;
using ActiveWinery.Administration.Views;
using NeoOrange.Infrastructure;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Administration.ViewModels
{
    public class ConfigurationViewModel : IViewModel, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fields

        private IWindowsManager _windowsManager;
        private bool _isDirty;

        #endregion

        #region Properties

        public bool CanCentreWindow
        {
            get
            {
                return ((CurrentRegion==null) || !(CurrentRegion.Equals("MainRegion")));
            }
        }

        public bool CanDockWindowLeft
        {
            get
            {
                return ((CurrentRegion==null) || !(CurrentRegion.Equals("LeftRegion")));
            }
        }

        public bool CanDockWindowRight
        {
            get
            {
                return ((CurrentRegion==null) || !(CurrentRegion.Equals("RightRegion")));
            }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsDirty"));
            }
        }

        public string CurrentRegion
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public ConfigurationViewModel(IWindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
            PropertyChanged += (s, e) => { };
        }

        #endregion

        #region Methods

        public void CentreWindow()
        {
            _windowsManager.MoveWindowTo(CurrentRegion, "MainRegion");
            FireDockNotifications();
        }

        public void CloseWindow()
        {
            _windowsManager.CloseWindow(CurrentRegion);
        }

        public void DockWindowLeft()
        {
            _windowsManager.MoveWindowTo(CurrentRegion, "LeftRegion");
            FireDockNotifications();
        }

        public void DockWindowRight()
        {
            _windowsManager.MoveWindowTo(CurrentRegion, "RightRegion");
            FireDockNotifications();
        }

        private void FireDockNotifications()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("CanDockWindowLeft"));
            PropertyChanged(this, new PropertyChangedEventArgs("CanDockWindowRight"));
            PropertyChanged(this, new PropertyChangedEventArgs("CanCentreWindow"));
        }

        public void ToggleDirty()
        {
            IsDirty = !IsDirty;
        }

        public void GroupsConfig()
        {
            _windowsManager.OpenWindow<GroupingView>("MainRegion", "GroupingWindow", true);
        }
        #endregion
    }
}