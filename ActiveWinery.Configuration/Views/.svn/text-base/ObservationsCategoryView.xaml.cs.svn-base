using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NeoOrange.Controls.Extensions;
using NeoOrange.Infrastructure;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Configuration.Views
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ObservationsCategoryView : UserControl, IView
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

        public int ZOrder { get; set; }

        #endregion

        #region Constructors

        public ObservationsCategoryView(IViewModelLocator viewModalLocator)
        {
            InitializeComponent();
            viewModalLocator.LocateViewModel(this);
        }

        #endregion

        #region Methods

        public void BringToFront()
        {
            Grid.SetZIndex(Presenter, 99);
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            Presenter = this.FindVisualParent<ContentControl>();
        }

        public void SendToBack()
        {
            Grid.SetZIndex(Presenter, 1);
        }

        public void SendToBack(int zOrder)
        {
            Grid.SetZIndex(Presenter, zOrder);
        }

        #endregion
    }
}