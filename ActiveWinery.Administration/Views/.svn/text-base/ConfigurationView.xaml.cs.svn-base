using System;
using System.Windows;
using System.Windows.Controls;
using NeoOrange.Controls.Extensions;
using NeoOrange.Infrastructure;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Administration.Views
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : UserControl, IView
    {
        #region Properties

        public ContentControl Presenter
        {
            get;
            set;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
        }

        private int _zOrder;
        public int ZOrder
        {
            get { return _zOrder; }
            set { SetZOrder(value); }
        }

        #endregion

        #region Constructors

        public ConfigurationView(IViewModelLocator viewModalLocator)
        {
            InitializeComponent();
            viewModalLocator.LocateViewModel(this);
        }

        #endregion

        #region Methods

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            Presenter = this.FindVisualParent<ContentControl>();

            if (Presenter != null)
            {
                Grid.SetZIndex(Presenter, ZOrder);
            }
        }

        private void SetZOrder(int value)
        {
            _zOrder = value;
            if (Presenter != null)
            {
                Grid.SetZIndex(Presenter, _zOrder);
            }
        }
        #endregion
    }
}