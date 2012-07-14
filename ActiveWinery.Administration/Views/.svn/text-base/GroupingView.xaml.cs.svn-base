using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ActiveWinery.Administration.Views
{
    /// <summary>
    /// Interaction logic for GroupingView.xaml
    /// </summary>
    public partial class GroupingView : UserControl, IView
    {
        #region Fields

        private int _zOrder;

        #endregion

        #region Properties

        public ContentControl Presenter { get; set; }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
        }

        public int ZOrder
        {
            get { return _zOrder; }
            set { SetZOrder(value); }
        }
        #endregion

        #region Constructors

        public GroupingView(IViewModelLocator viewModalLocator)
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
