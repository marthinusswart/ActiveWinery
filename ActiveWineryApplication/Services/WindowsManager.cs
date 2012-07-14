using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ActiveWinery.Models;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using NeoOrange.Infrastructure;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Services
{
    public class WindowsManager : IWindowsManager, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fields

        private IUnityContainer _container;

        private Dictionary<string, OpenWindow> _openWindowNames = new Dictionary<string, OpenWindow>();
        private Dictionary<IView, OpenWindow> _openWindowViews = new Dictionary<IView, OpenWindow>();
        private Dictionary<Guid, OpenWindow> _openWindows = new Dictionary<Guid, OpenWindow>();
        private IRegionManager _regionManager;

        #endregion

        #region Constructors

        public WindowsManager(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            PropertyChanged += (s, e) => { };
        }

        #endregion

        #region Methods

        private void ActivateWindow(OpenWindow window)
        {
            BringToFront(window);
            SendToBackExcept(window);
        }

        private void BringToFront(OpenWindow window)
        {
            window.View.ZOrder = 99;
        }

        private void BringToFront(IView view)
        {
            view.ZOrder = 99;
        }

        private void SendToBack(OpenWindow window)
        {
            window.View.ZOrder = 1;
        }

        private void SendToBackExcept(OpenWindow window)
        {
            foreach (var region in _regionManager.Regions)
            {
                if (!region.Name.Equals(window.CurrentRegion))
                {
                    var view = region.ActiveViews.FirstOrDefault();
                    if ((view != null) && (view is IView))
                    {
                        SendToBack(_openWindowViews[(IView)view]);
                    }
                }
            }
        }

        public void CloseWindow(string targetRegion)
        {
            var region = _regionManager.Regions[targetRegion];
            var view = region.ActiveViews.FirstOrDefault();

            if (view is IView)
            {
                var openWindow = _openWindowViews[(IView)view];
                _openWindowViews.Remove((IView)view);
                _openWindowNames.Remove(openWindow.Name);
                _openWindows.Remove(openWindow.WindowId);
                region.Remove(view);
                var previousView = region.Views.FirstOrDefault();
                if (previousView != null)
                {
                    region.Activate(previousView);
                }
            }

        }

        public void MoveWindowTo(string currentRegion, string targetRegion)
        {
            var region = _regionManager.Regions[currentRegion];
            var view = region.ActiveViews.FirstOrDefault();
            BringToFront((IView)view);

            region.Remove(view);
            var firstView = region.Views.FirstOrDefault();
            if (firstView != null)
            {
                region.Activate(firstView);
            }

            if (view is IView)
            {
                var iView = (IView)view;
                iView.ViewModel.CurrentRegion = targetRegion;
                var openWindow = _openWindowViews[iView];
                SendToBackExcept(openWindow);
            }

            region = _regionManager.Regions[targetRegion];
            region.Add(view);
            region.Activate(view);
        }

        public Guid OpenWindow<T>(string targetRegion, string name, bool singleton)
        {

            if (_openWindowNames.ContainsKey(name))
            {
                if (singleton)
                {
                    var currentOpenWindow = _openWindowNames[name];
                    ActivateWindow(currentOpenWindow);
                    return currentOpenWindow.WindowId;
                }
                else
                {
                    name = name + DateTime.Now.Millisecond;
                }
            }


            var view = _container.Resolve<T>();

            var openWindow = new OpenWindow()
                                 {
                                     Name = name,
                                     WindowId = Guid.NewGuid(),
                                     View = (IView)view
                                 };

            _openWindows.Add(openWindow.WindowId, openWindow);
            _openWindowNames.Add(openWindow.Name, openWindow);
            _openWindowViews.Add(openWindow.View, openWindow);

            if (view is IView)
            {
                ((IView)view).ViewModel.CurrentRegion = targetRegion;
            }

            var region = _regionManager.Regions[targetRegion];
            region.Add(view);
            region.Activate(view);
            ActivateWindow(openWindow);

            return openWindow.WindowId;
        }

        public Guid OpenWindow<T>(string targetRegion, string name)
        {
            return OpenWindow<T>(targetRegion, name, false);
        }

        #endregion
    }
}
